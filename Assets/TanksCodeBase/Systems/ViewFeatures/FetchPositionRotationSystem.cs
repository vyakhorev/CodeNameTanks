using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class FetchPositionRotationSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> regularEntityPositions;
    readonly IGroup<GameEntity> characterEntityPositions;
  
    public FetchPositionRotationSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      regularEntityPositions = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.Position,
            GameMatcher.Rotation,
            GameMatcher.View
          ).
          NoneOf(
            GameMatcher.AvatarMove
          )
      );
      characterEntityPositions = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.Position,
            GameMatcher.Rotation,
            GameMatcher.View,
            GameMatcher.AvatarMove
          )
      );
    }

    public void Execute()
    {
      foreach (GameEntity e in regularEntityPositions.GetEntities())
      {
        e.view.gameObject.transform.position = e.position.value;
        e.view.gameObject.transform.rotation = e.rotation.value;
        //Debug.DrawLine(e.position.value, e.position.value + e.rotation.value*Vector3.forward*2, Color.green);
      }
      foreach (GameEntity e in characterEntityPositions.GetEntities())
      {
        // Position is dictated by character controller (avatar move)
        e.position.value = e.view.gameObject.transform.position;
        // However rotation is set by a special system
        e.view.gameObject.transform.rotation = e.rotation.value;
        //Debug.DrawLine(e.position.value, e.position.value + e.rotation.value*Vector3.forward*2, Color.green);
      }
      
    }
  }
}
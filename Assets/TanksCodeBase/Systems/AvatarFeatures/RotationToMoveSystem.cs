using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  /* Instantly rotates player / other tanks to the moving direction. */
  public class RotationToMoveSystem : IExecuteSystem
  {
    readonly IGroup<GameEntity> gameMoversGroup;
    readonly GameContext gameContext;
    
    public RotationToMoveSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      gameMoversGroup = contexts.game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.AvatarMove,
          GameMatcher.Rotation,
          GameMatcher.TraceMovement
        )
      );
    }
    
    public void Execute()
    {
      foreach (GameEntity ent_i in gameMoversGroup.GetEntities())
      {
        if (ent_i.traceMovement.movingThisFrame)
        {
          ent_i.rotation.value = Quaternion.LookRotation(ent_i.traceMovement.thisFrameMoveDirection.normalized, Vector3.up);  
        }
      }
    }
    
  }
}
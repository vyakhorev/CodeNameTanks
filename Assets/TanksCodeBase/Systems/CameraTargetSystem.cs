using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class CameraTargetSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> cameraTargetGroup;
    readonly IGroup<GameEntity> trainGroup;

    public CameraTargetSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      
      cameraTargetGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.CameraTarget,
            GameMatcher.Position
          )
      );
      
      trainGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.PathFollower,
            GameMatcher.Position
          )
      );
    }

    public void Execute()
    {
      // TODO may be there is a solution for single entities?
      foreach (GameEntity camEnt in cameraTargetGroup.GetEntities())
      {
        foreach (GameEntity trainEnt in trainGroup.GetEntities())
        {
          if (trainEnt.pathFollower.pathId == 0)
          {
            camEnt.position.value = trainEnt.position.value;
          }
        }
        
      }
      
    }
    
  }
}
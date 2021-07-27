using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class TraceMovementSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> movableGroup;
    
    public TraceMovementSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      movableGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.Position,
            GameMatcher.TraceMovement
          ).
          AnyOf(
            GameMatcher.Move,
            GameMatcher.AvatarMove,
            GameMatcher.KinematicMove
          )
      );
    }

    public void Execute()
    {
      foreach (GameEntity ent_i in movableGroup.GetEntities())
      {
        ent_i.traceMovement.lastMovedVector = ent_i.position.value - ent_i.traceMovement.lastPosition;
        ent_i.traceMovement.lastPosition = ent_i.position.value;
        if (ent_i.traceMovement.lastMovedVector.magnitude > 0)
        {
          ent_i.traceMovement.movedLastFrame = true;
        }
        else
        {
          ent_i.traceMovement.movedLastFrame = false;
        }
        
        if (ent_i.hasAvatarMove)
        {
          ent_i.traceMovement.thisFrameMoveDirection = ent_i.avatarMove.moveDirection;  
        }
        else if (ent_i.hasKinematicMove)
        {
          ent_i.traceMovement.thisFrameMoveDirection = ent_i.kinematicMove.moveDirection;
        }
        else if (ent_i.hasMove)
        {
          ent_i.traceMovement.thisFrameMoveDirection = ent_i.move.direction;
        }

        if (ent_i.traceMovement.thisFrameMoveDirection.magnitude > 0)
        {
          ent_i.traceMovement.movingThisFrame = true;
        }
        else
        {
          ent_i.traceMovement.movingThisFrame = false;
        }

      }
    }
    
  }
}
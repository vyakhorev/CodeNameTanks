using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class SetupTraceMovementSystem : ReactiveSystem<GameEntity>
  {
    readonly GameContext gameContext;
    
    public SetupTraceMovementSystem(Contexts contexts) : base(contexts.game)
    {
      gameContext = contexts.game;
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
      return context.CreateCollector(
        GameMatcher.
          AllOf(
            GameMatcher.Position
          ).
          AnyOf(
            GameMatcher.AvatarMove,
            GameMatcher.KinematicMove,
            GameMatcher.Move
          ).
          NoneOf(
            GameMatcher.TraceMovement
          )
      );
    }

    protected override bool Filter(GameEntity entity)
    {
      return entity.hasPosition && 
             (entity.hasAvatarMove || 
              entity.hasKinematicMove ||
              entity.hasMove) &&
             !entity.hasTraceMovement;
    }

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity ent_i in entities)
      {
        ent_i.AddTraceMovement(newLastMovedVector: Vector3.zero, 
          newThisFrameMoveDirection: Vector3.zero, 
          newLastPosition: ent_i.position.value, 
          newMovedLastFrame: false,
          newMovingThisFrame: false);
      }
    }
  }
}
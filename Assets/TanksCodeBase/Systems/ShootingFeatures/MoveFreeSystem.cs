using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class MoveFreeSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> movableGroup;
    
    public MoveFreeSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      movableGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.Move,
            GameMatcher.Position
            )
      );
    }

    public void Execute()
    {
      foreach (GameEntity ent_i in movableGroup.GetEntities())
      {
        ent_i.position.value += ent_i.move.direction * ent_i.move.speed * Time.deltaTime;
      }
    }
  }
}
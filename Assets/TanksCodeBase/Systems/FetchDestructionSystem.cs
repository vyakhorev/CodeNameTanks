using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class FetchDestructionSystem : IExecuteSystem
  {
    
    readonly GameContext _gameContext;
    readonly IGroup<GameEntity> _destructables;
  
    public FetchDestructionSystem(Contexts contexts)
    {
      _gameContext = contexts.game;
      _destructables = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.Destructable, 
            GameMatcher.View
            )
      );
    }

    public void Execute()
    {
      foreach (GameEntity e in _destructables.GetEntities())
      {
        if (e.destructable.damageTaken >= e.destructable.damageMax && !e.destructable.isDestroyed)
        {
          if (!e.hasLifespan)
          {
            e.AddLifespan(0.0f);  
          }
          else
          {
            e.lifespan.timeToDestroy = 0.0f;
          }
          e.destructable.isDestroyed = true;
        }
      }
    }
  }
}
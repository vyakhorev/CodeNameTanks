using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  public class InteractionCounterSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> interactiveGroup;
    readonly IGroup<GameEntity> interactorsGroup;

    public InteractionCounterSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      interactiveGroup = contexts.game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.InteractiveZone,
          GameMatcher.Position,
          GameMatcher.View)
        );
      interactorsGroup = contexts.game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Position,
          GameMatcher.Player)
        );
    }

    public void Execute()
    {
      // Should optimize it one day
      foreach (GameEntity e in interactiveGroup.GetEntities())
      {
        foreach (GameEntity p in interactorsGroup.GetEntities())
        {
          if ((e.position.value - p.position.value).sqrMagnitude < e.interactiveZone.radius)
          {
            
            e.interactiveZone.waitedTime += Time.deltaTime;
          }
          else
          {
            e.interactiveZone.waitedTime = 0f;
          }
        }

        if (e.interactiveZone.waitedTime > e.interactiveZone.timeToTrigger)
        {
          e.interactiveZone.isTriggered = true;
        }
        else
        {
          e.interactiveZone.isTriggered = false;
        }
        
      }
    }
  }
}
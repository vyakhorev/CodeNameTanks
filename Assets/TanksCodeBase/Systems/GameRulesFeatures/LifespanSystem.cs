using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  public class LifespanSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> lifespanGroup;

    public LifespanSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      lifespanGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Lifespan, GameMatcher.View));
    }

    public void Execute()
    {
      foreach (GameEntity e in lifespanGroup.GetEntities())
      {
        e.lifespan.timeToDestroy -= Time.deltaTime;
        if (e.lifespan.timeToDestroy <= 0)
        {
          GameObject go = e.view.gameObject;
          go.SetActive(false);  // return to pool
          go.Unlink();
          e.Destroy();
        }
      }
    }
  }
}
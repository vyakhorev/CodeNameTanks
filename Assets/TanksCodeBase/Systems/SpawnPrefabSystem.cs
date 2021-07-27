using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  /*
   * Get an object from pool and spawn it, for each entity with ViewPrefab and Position with no View
   */
  public class SpawnPrefabSystem : ReactiveSystem<GameEntity>
  {
    readonly GameContext gameContext;

    public SpawnPrefabSystem(Contexts contexts) : base(contexts.game)
    {
      gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
      return context.CreateCollector(
        GameMatcher.
          AllOf(
            GameMatcher.ViewPrefab,
            GameMatcher.Position,
            GameMatcher.Rotation
            ).
          NoneOf(GameMatcher.View)
        );
    }

    protected override bool Filter(GameEntity entity)
    {
      return entity.hasViewPrefab && entity.hasPosition && entity.hasRotation && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity e in entities)
      {
        // Won't work multithread since we pull objects based on activity
        GameObject go = ObjectPools.instance.PoolObject(e.viewPrefab.prefabGameObject);
        
        go.transform.position = e.position.value;
        go.transform.rotation = e.rotation.value;
        go.SetActive(true);
        e.AddView(go);
        go.Link(e);
      }
    }
  }
}
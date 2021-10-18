
using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class GameBootstrapSystem : IInitializeSystem
  {
    readonly LevelContext levelContext;
    readonly IGroup<LevelEntity> levelGenerateGroup;

    public GameBootstrapSystem(Contexts contexts)
    {
      levelContext = contexts.level;
      levelGenerateGroup = contexts.level.GetGroup(
        LevelMatcher.
          AllOf(
            LevelMatcher.LevelGenerateTask
          )
      );
    }

    public void Initialize()
    {
      foreach (LevelEntity ent_i in levelGenerateGroup.GetEntities())
      {
        Vector2Int xy = ent_i.levelGenerateTask.levelGenerationSettings.levelSize;
      }
    }
  }
}
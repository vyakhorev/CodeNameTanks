
using UnityEngine;
using Entitas;

namespace TanksCodeBase
{
  [Level]
  public class LevelGenerateTaskComponent : IComponent
  {
    public SOLevelGenerationSettings levelGenerationSettings;
  }
}
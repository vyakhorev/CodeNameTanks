using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class LevelGenerationSystem : IExecuteSystem
  {
    readonly LevelContext levelContext;
    
    
    public LevelGenerationSystem(Contexts contexts)
    {
      levelContext = contexts.level;
      
    }

    public void Execute()
    {
      
    }
  }
}
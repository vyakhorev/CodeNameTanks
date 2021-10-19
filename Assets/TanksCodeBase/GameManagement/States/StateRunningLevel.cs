using System.Collections.Generic;
using Entitas;

namespace TanksCodeBase
{
  public class StateRunningLevel : IGameState
  {
    private GameContext gameContext;
    public Systems updateSystems;
    public Systems fixedUpdateSystems;
    
    public void Enter()
    {
      
    }

    public void Exit()
    {
      
    }

    public void RunUpdate()
    {
      updateSystems.Execute();
      updateSystems.Cleanup();
    }

    public void RunFixedUpdate()
    {
      fixedUpdateSystems.Execute();
      fixedUpdateSystems.Cleanup();
    }
    
  }
}
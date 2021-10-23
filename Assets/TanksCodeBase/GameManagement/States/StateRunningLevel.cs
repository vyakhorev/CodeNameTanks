using System.Collections.Generic;
using Entitas;

namespace TanksCodeBase
{
  public class StateRunningLevel : GameState
  {
    private GameContext gameContext;
    public Systems updateSystems;
    public Systems fixedUpdateSystems;
    
    public override void Enter()
    {
      
    }

    public override void Exit()
    {
      
    }

    public override void RunUpdate()
    {
      updateSystems.Execute();
      updateSystems.Cleanup();
    }

    public override void RunFixedUpdate()
    {
      fixedUpdateSystems.Execute();
      fixedUpdateSystems.Cleanup();
    }
    
  }
}
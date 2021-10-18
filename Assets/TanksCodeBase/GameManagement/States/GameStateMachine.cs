using System.Collections.Generic;

namespace TanksCodeBase
{
  public class GameStateMachine
  {
    
    private IGameState CurrentState;

    public void SetupMachine(IGameState startingState)
    {
      CurrentState = startingState;
      startingState.Enter();
    }
    
    public void EnterState(IGameState newState)
    {
      CurrentState.Exit();
      CurrentState = newState;
      newState.Enter();    
    }

    public void RunUpdate()
    {
      CurrentState.RunUpdate();
    }

    public void RunFixedUpdate()
    {
      CurrentState.RunFixedUpdate();
    }
    



  }
  
  
}
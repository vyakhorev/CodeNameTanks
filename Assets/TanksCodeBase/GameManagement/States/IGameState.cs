using System.Collections.Generic;

namespace TanksCodeBase
{
  public interface IGameState
  {
   
    void Enter();

    void Exit();
    
    void RunUpdate();
    
    void RunFixedUpdate();
    
  }
}
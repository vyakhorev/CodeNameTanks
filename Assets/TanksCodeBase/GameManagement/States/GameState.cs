using System;
using System.Collections.Generic;

namespace TanksCodeBase
{
  public abstract class GameState
  {
    
    public event EventHandler BlackboardUpdated;
    
    public abstract void Enter();

    public abstract void Exit();
    
    public abstract void RunUpdate();
    
    public abstract void RunFixedUpdate();
    
  }
}
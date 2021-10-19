using System;

namespace TanksCodeBase
{
  public class Transition
  {

    public IGameState fromState;
    public IGameState toState;

    public Func<GameStateMachine, bool> fireCondition;

  }
}
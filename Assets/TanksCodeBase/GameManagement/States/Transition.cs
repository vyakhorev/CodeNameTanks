using System;

namespace TanksCodeBase
{
  public class Transition
  {

    public GameState fromState;
    public GameState toState;

    public Func<GameStateMachine, bool> fireCondition;

  }
}
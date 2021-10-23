using System.Collections.Generic;
using UnityEngine;

namespace TanksCodeBase
{
  public class GameStateMachine
  {

    public BlackBoard blackBoard;
    private GameState CurrentState;
    private List<Transition> transitions;
    private float transitionFreq = 0.5f;
    private float transitionCheck;

    public GameStateMachine()
    {
      blackBoard = new BlackBoard();
      transitions = new List<Transition>();
      transitionCheck = 0f;
    }

    public void AddTransition(Transition transition)
    {
      transitions.Add(transition);
    }
    
    public void SetupMachine(GameState startingState)
    {
      CurrentState = startingState;
      startingState.Enter();
    }
    
    public void EnterState(GameState newState)
    {
      Debug.Log("Entering new state");
      CurrentState.Exit();
      CurrentState = newState;
      newState.Enter();    
    }

    public void CheckTransitions()
    {
      foreach (Transition tr_i in transitions)
      {
        if (tr_i.fromState == CurrentState)
        {
          if (tr_i.fireCondition(this))
          {
            EnterState(tr_i.toState);
          }
        }
      }
    }
    
    public void RunUpdate()
    {
      CurrentState.RunUpdate();
      transitionCheck += Time.deltaTime;
      if (transitionCheck > transitionFreq)
      {
        CheckTransitions();
        transitionCheck = 0;
      }
      
    }

    public void RunFixedUpdate()
    {
      CurrentState.RunFixedUpdate();
    }
    



  }
  
  
}
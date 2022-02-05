using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class StateRunningLevel : GameState
  {
    private GameContext gameContext;
    public Systems updateSystems;
    public Systems fixedUpdateSystems;
    public LevelManager levelManager;
    
    public override void Enter()
    {
      Debug.Log("Entering game from a real state machine");
      levelManager.fromLobbyToTrain();
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
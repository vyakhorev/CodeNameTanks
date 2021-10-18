using System;
using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TanksCodeBase
{

  public class GameController : MonoBehaviour
  {
    Systems fixedUpdateSystems;
    Systems updateSystems;
    public static GameController instance;
    public GameContext gameContext;

    private GameStateMachine gameSM;

    private void Awake()
    {
      instance = this;
    }

    void Start()
    {
      StateRunningLevel startState = new StateRunningLevel();
      startState.InitState();
      gameSM = new GameStateMachine();
      gameSM.SetupMachine(startState);
      
      // Contexts contexts = Contexts.sharedInstance;
      // gameContext = contexts.game;
      //
      // updateSystems = new Feature("Regular update systems")
      //   .Add(new InputFeatures(contexts))
      //   .Add(new ViewFeatures(contexts))
      //   .Add(new AIFeatures(contexts))
      //   .Add(new GameRulesFeatures(contexts))
      //   .Add(new AvatarFeatures(contexts));
      //
      // fixedUpdateSystems = new Feature("Fixed update systems")
      //   .Add(new ShootingFeatures(contexts));
      //
      // updateSystems.Initialize();
      // fixedUpdateSystems.Initialize();
    }
    
    void Update()
    {
      gameSM.RunUpdate();
      
      // updateSystems.Execute();
      // updateSystems.Cleanup();
    }
    
    void FixedUpdate()
    {
      gameSM.RunFixedUpdate();
      
      // fixedUpdateSystems.Execute();
      // fixedUpdateSystems.Cleanup();
    }
  }
}
using System;
using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TanksCodeBase
{

  [RequireComponent(typeof(LevelManager))]
  public class GameController : MonoBehaviour
  {
    /* In different states different systems are active.
     When we move from state to state, we call cleanup and
     init systems corresponding to new state. */
    Systems fixedUpdateSystems;
    Systems updateSystems;
    public static GameController instance;
    public GameContext gameContext;

    public GameStateMachine gameSM;
    
    private LevelManager levelManager;

    private void Awake()
    {
      instance = this;
      levelManager = GetComponent<LevelManager>();
      DontDestroyOnLoad(this);
    }

    void SetupGameStateMachine()
    {
      // All states
      var stateGameLoad = new StateGameLoad();
      var stateStartingState = new StateStartingScene();
      var stateRunningLevel = new StateRunningLevel();
      var stateRunningAndGeneratingLevel = new StateRunningAndGeneratingLevel();
      
      // Features for states
      Contexts contexts = Contexts.sharedInstance;
      gameContext = contexts.game;
      
      updateSystems = new Feature("Regular update systems")
        .Add(new InputFeatures(contexts))
        .Add(new ViewFeatures(contexts))
        .Add(new AIFeatures(contexts))
        .Add(new GameRulesFeatures(contexts))
        .Add(new AvatarFeatures(contexts));
          
      fixedUpdateSystems = new Feature("Fixed update systems")
        .Add(new ShootingFeatures(contexts));
        
      
      
      // Setup these states
      stateStartingState.updateSystems = updateSystems;
      stateStartingState.fixedUpdateSystems = fixedUpdateSystems;
      
      stateRunningLevel.updateSystems = updateSystems;
      stateRunningLevel.fixedUpdateSystems = fixedUpdateSystems;
      stateRunningLevel.levelManager = levelManager;
      
      // The state machine instance
      gameSM = new GameStateMachine();

      // Setup conditional transitions

      Func<GameStateMachine, bool> gameIsLoaded = machine =>
      {
        return machine.blackBoard.CheckFlag("GameLoaded");
      };
      
      Func<GameStateMachine, bool> lobbyLeft = machine =>
      {
        return machine.blackBoard.CheckFlag("LobbyLeft");
      };
      
      var loadToStarting = new Transition();
      loadToStarting.fromState = stateGameLoad;
      loadToStarting.toState = stateStartingState;
      loadToStarting.fireCondition = gameIsLoaded;
      
      var startingToRunning = new Transition();
      startingToRunning.fromState = stateStartingState;
      startingToRunning.toState = stateRunningLevel;
      startingToRunning.fireCondition = lobbyLeft;
      
      gameSM.AddTransition(loadToStarting);
      gameSM.AddTransition(startingToRunning);
        
      gameSM.SetupMachine(stateGameLoad);
    }
    
    

    void Start()
    {
      SetupGameStateMachine();
      gameSM.blackBoard.SetFlag("GameLoaded", true);

    }
    
    void Update()
    {
      gameSM.RunUpdate();
      
    }
    
    void FixedUpdate()
    {
      gameSM.RunFixedUpdate();
      
    }
  }
}
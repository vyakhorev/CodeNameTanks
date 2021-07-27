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

    private void Awake()
    {
      instance = this;
    }

    void Start()
    {
      Contexts contexts = Contexts.sharedInstance;
      gameContext = contexts.game;
      
      updateSystems = new Feature("Regular update systems")
        .Add(new ViewFeatures(contexts))
        .Add(new AIFeatures(contexts))
        .Add(new GameRulesFeatures(contexts))
        .Add(new CharacterFeatures(contexts));
      
      fixedUpdateSystems = new Feature("Fixed update systems")
        .Add(new ShootingFeatures(contexts));
      
      updateSystems.Initialize();
      fixedUpdateSystems.Initialize();
    }

    void Update()
    {
      updateSystems.Execute();
      updateSystems.Cleanup();
    }
    
    void FixedUpdate()
    {
      fixedUpdateSystems.Execute();
      fixedUpdateSystems.Cleanup();
    }
  }
}
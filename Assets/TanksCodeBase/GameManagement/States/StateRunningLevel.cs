using Entitas;

namespace TanksCodeBase
{
  public class StateRunningLevel : IGameState
  {
    private GameContext gameContext;
    private Systems updateSystems;
    private Systems fixedUpdateSystems;

    public void InitState()
    {
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
      
      updateSystems.Initialize();
      fixedUpdateSystems.Initialize();
    }
    
    public void Enter()
    {
      
    }

    public void Exit()
    {
      
    }

    public void RunUpdate()
    {
      updateSystems.Execute();
      updateSystems.Cleanup();
    }

    public void RunFixedUpdate()
    {
      fixedUpdateSystems.Execute();
      fixedUpdateSystems.Cleanup();
    }
    
  }
}
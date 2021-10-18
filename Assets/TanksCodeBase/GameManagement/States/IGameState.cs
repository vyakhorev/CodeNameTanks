namespace TanksCodeBase
{
  public interface IGameState
  {
    void InitState();
    
    void Enter();

    void Exit();
    
    void RunUpdate();
    
    void RunFixedUpdate();
    
  }
}
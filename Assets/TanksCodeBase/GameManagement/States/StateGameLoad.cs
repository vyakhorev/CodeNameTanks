using UnityEngine;

namespace TanksCodeBase
{
  public class StateGameLoad : IGameState
  {

    public void Enter()
    {
      Debug.Log("Loading game");
    }

    public void Exit()
    {
      Debug.Log("Game loaded");
    }

    public void RunUpdate()
    {
      
    }

    public void RunFixedUpdate()
    {
      
    }
  }
}
using UnityEngine;

namespace TanksCodeBase
{
  public class StateGameLoad : GameState
  {

    public override void Enter()
    {
      Debug.Log("Loading game");

    }

    public override void Exit()
    {
      Debug.Log("Game loaded");
    }

    public override void RunUpdate()
    {
      
    }

    public override void RunFixedUpdate()
    {
      
    }
  }
}
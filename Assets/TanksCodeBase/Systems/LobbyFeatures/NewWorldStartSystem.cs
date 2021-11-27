using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  /* Start a new level from lobby */
  public class NewWorldStartSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> teleportsGroup;
    
    public NewWorldStartSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      teleportsGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.LobbyTeleport
          )
      );
    }
    
    public void Execute()
    {
      foreach (GameEntity ent_i in teleportsGroup.GetEntities())
      {
        if (ent_i.lobbyTeleport.waitedTime > 2f)
        {
          Debug.Log("Do teleport");
        } 
      }
    }
    
  }
}
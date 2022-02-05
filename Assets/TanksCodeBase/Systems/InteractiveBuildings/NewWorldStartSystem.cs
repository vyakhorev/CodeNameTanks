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
            GameMatcher.LobbyTeleport,
            GameMatcher.InteractiveZone
          )
      );
    }
    
    public void Execute()
    {
      foreach (GameEntity ent_i in teleportsGroup.GetEntities())
      {
        if (ent_i.interactiveZone.isTriggered)
        {
          ent_i.interactiveZone.underExecution = true;
          ent_i.interactiveZone.waitedTime = 0f;
          ent_i.interactiveZone.isTriggered = false;
          
          GameController gameContr = GameController.instance;
          gameContr.gameSM.blackBoard.SetFlag("LobbyLeft", true);
          
          ent_i.interactiveZone.underExecution = false;
        } 
      }
    }
    
    
  }
}
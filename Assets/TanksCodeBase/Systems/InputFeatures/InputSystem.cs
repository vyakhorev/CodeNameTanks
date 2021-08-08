using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TanksCodeBase
{
  /* Wires input events directly to an entity
   with PlayerInputEntitasWiring. 
   Fetches camera rotation to match input to possible
   camera changes. */
  public class InputSystem : IExecuteSystem
  {
    private readonly InputContext inputContext;
    private readonly GameContext gameContext;
    private List<PlayerInputEntitasWiring> players;
     
    
    public InputSystem(Contexts contexts)
    {
      inputContext = contexts.input;
      gameContext = contexts.game;
      setupPlayerManager();
      players = new List<PlayerInputEntitasWiring>();
    }

    private void setupPlayerManager()
    {
      PlayerInputManager playerInputManager = PlayerInputManager.instance;
      playerInputManager.EnableJoining();
      playerInputManager.onPlayerJoined += newPlayerInput => addPlayer(newPlayerInput);
      playerInputManager.onPlayerLeft += removePlayer;
    }

    // Move player to spawn point
    void addPlayer(PlayerInput newPlayerInput)
    {
      GameObject playerCharacter = newPlayerInput.gameObject;
      
      Vector2 spawnPosition = new Vector2(-7, -2);
      Quaternion spawnRotation = Quaternion.identity;
        
      // Makes a player and wires up events from newPlayerInput to input entities
      PlayerInputEntitasWiring inputWiring = new PlayerInputEntitasWiring(newPlayerInput, 
                                                                          inputContext, 
                                                                          gameContext, 
                                                                          playerCharacter,
                                                                          spawnPosition,
                                                                          spawnRotation);
      players.Add(inputWiring);
      
    }

    void removePlayer(PlayerInput leavingPlayerInput)
    {
      // TODO - clean players
    }

    public void Execute()
    {
      
    }
    
  }
}
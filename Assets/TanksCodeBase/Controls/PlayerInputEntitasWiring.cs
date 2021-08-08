using UnityEngine;
using UnityEngine.InputSystem;

namespace TanksCodeBase
{
  public class PlayerInputEntitasWiring
  {
    private readonly InputContext inputContext;
    private readonly GameContext gameContext;
    //private PlayerInput input;
    private readonly GameObject playerGameObject;
    private readonly InputEntity playerInputEntity;
    private readonly GameEntity playerGameEntity;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction fireAction;
    
    public PlayerInputEntitasWiring(PlayerInput playerInput, 
      InputContext inputContext, 
      GameContext gameContext,
      GameObject playerGameObject,
      Vector2 spawnPosition,
      Quaternion spawnRotation)
    {
      // A possible alternative is multireactive system
      // https://github.com/sschmid/Entitas-CSharp/wiki/MultiReactiveSystem-Tutorial
      this.inputContext = inputContext;
      this.gameContext = gameContext;
      this.playerGameObject = playerGameObject;
      
      playerGameEntity = createPlayerGameEntity();
      
      InputEntity inpEnt = this.inputContext.CreateEntity();
      inpEnt.AddInput(Vector2.zero, false, false);
      inpEnt.AddGameInputLink(playerGameEntity);
      playerInputEntity = inpEnt;
      
      
      movePlayerToSpawn(spawnPosition, spawnRotation);
      mapActions(playerInput);
    }

    private GameEntity createPlayerGameEntity()
    {
      GameEntity playerEnt = this.gameContext.CreateEntity();
      playerEnt.AddPlayer(0, true);
      playerEnt.AddView(this.playerGameObject);
      playerEnt.AddCharMoveSpeed(5f);
      playerEnt.AddAvatarMove(Vector3.zero, false);
      playerEnt.AddPosition(Vector3.zero);
      playerEnt.AddRotation(Quaternion.identity);
      playerEnt.AddShooter(GameInstance.instance.AvatarsSetup.possibleGunSetups[0],0f,false);
      playerEnt.AddDestructable(1, 0, false);
      return playerEnt;
    }

    private void movePlayerToSpawn(Vector2 spawnPosition,
      Quaternion spawnRotation)
    {
      // Teleport components are removed after being processed
      playerGameEntity.AddTeleport(spawnPosition, spawnRotation, false);
    }

    private void mapActions(PlayerInput playerInput)
    {
      moveAction = playerInput.currentActionMap.FindAction("Movement");
      jumpAction = playerInput.currentActionMap.FindAction("Jump");
      fireAction = playerInput.currentActionMap.FindAction("Fire");

      moveAction.performed += OnMovement;
      moveAction.canceled += OnMovement;
      jumpAction.performed += OnJump;
      jumpAction.canceled += OnJump;
      fireAction.performed += OnFire;
      fireAction.canceled += OnFire;
    }
    
    private void OnFire(InputAction.CallbackContext context)
    {
      
      float fireFlt = context.ReadValue<float>();
      if (fireFlt > 0)
      {
        playerInputEntity.input.fired = true;
      }
      else
      {
        playerInputEntity.input.fired = false;
      }
      
    }

    private void OnJump(InputAction.CallbackContext context)
    {
      // context.action.triggered
      float jumpFlt = context.ReadValue<float>();
      if (jumpFlt > 0)
      {
        playerInputEntity.input.jumped = true;
      }
      else
      {
        playerInputEntity.input.jumped = false;
      }
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
      playerInputEntity.input.move = context.ReadValue<Vector2>();
    }
    
  }
}
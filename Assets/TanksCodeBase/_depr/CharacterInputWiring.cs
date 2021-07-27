
/* DEPR */

using UnityEngine;
using UnityEngine.InputSystem;

namespace TanksCodeBase
{
  [RequireComponent(typeof(CharacterController))]
  [RequireComponent(typeof(PlayerInput))]
  [RequireComponent(typeof(Shooter))]
  public class CharacterInputWiring : MonoBehaviour
  {
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;

    //private GlobalInputMap vInputMap;
    private Vector2 fCharacterMove;
    private bool fCharJumped;
    private bool fCharFired;

    private CharacterController cmpCharacterController;
    private bool groundedPlayer;

    private PlayerInput cmpPlayerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction fireAction;
    private Shooter cmpShooter;

    private void Start()
    {
      cmpCharacterController = GetComponent<CharacterController>();
      fCharJumped = false;
      fCharFired = false;

      cmpShooter = GetComponent<Shooter>();
      
      cmpPlayerInput = GetComponent<PlayerInput>();
      //playerInput.onActionTriggered += ReadAction;
      /*moveAction = cmpPlayerInput.currentActionMap.FindAction("Movement");
      jumpAction = cmpPlayerInput.currentActionMap.FindAction("Jump");
      fireAction = cmpPlayerInput.currentActionMap.FindAction("Fire");

      moveAction.performed += OnMovement;
      moveAction.canceled += OnMovement;
      jumpAction.performed += OnJump;
      jumpAction.canceled += OnJump;
      fireAction.performed += OnFire;
      fireAction.canceled += OnFire;*/

      cmpShooter.SetGunSetup(GameInstance.instance.AvatarsSetup.possibleGunSetups[0]);

    }

    private void ReadAction(InputAction.CallbackContext context)
    {
      if (context.action == moveAction)
      {
        OnMovement(context);
      }

      if (context.action == jumpAction)
      {
        OnJump(context);
      }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
      fCharacterMove = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
      // context.action.triggered
      float jumpFlt = context.ReadValue<float>();
      if (jumpFlt > 0)
      {
        fCharJumped = true;
      }
      else
      {
        fCharJumped = false;
      }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
      float fireFlt = context.ReadValue<float>();
      if (fireFlt > 0)
      {
        fCharFired = true;
      }
      else
      {
        fCharFired = false;
      }
    }

    private void Update()
    {
      HandleMovementUpdate();
      HandleFiring();
    }

    private void HandleMovementUpdate()
    {
      groundedPlayer = cmpCharacterController.isGrounded;
      if (groundedPlayer && playerVelocity.y < 0)
      {
        playerVelocity.y = 0f;
      }

      Vector3 move = new Vector3(fCharacterMove.x, 0, fCharacterMove.y);
      cmpCharacterController.Move(Time.deltaTime * playerSpeed * move);

      if (move != Vector3.zero)
      {
        gameObject.transform.forward = move;
      }

      // Changes the height position of the player.
      if (fCharJumped && groundedPlayer)
      {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
      }

      playerVelocity.y += gravityValue * Time.deltaTime;
      cmpCharacterController.Move(playerVelocity * Time.deltaTime);
    }
    
    private void HandleFiring()
    {
      if (fCharFired)
      {
        cmpShooter.Shoot();
      }
    }
    
    
  }
}
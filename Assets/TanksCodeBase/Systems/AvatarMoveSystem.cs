using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class AvatarMoveSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> avatarMovingGroup;
    
    public AvatarMoveSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      avatarMovingGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.CharMoveSpeed,
            GameMatcher.AvatarMove,
            GameMatcher.Position,
            GameMatcher.View,
            GameMatcher.CharacterController
          )
      );
    }

    public void Execute()
    {
      foreach (GameEntity ent_i in avatarMovingGroup.GetEntities())
      {
        Vector3 moveVec = ent_i.avatarMove.moveDirection * ent_i.charMoveSpeed.speed * Time.deltaTime;
        CharacterController cc = ent_i.characterController.characterController;
        CollisionFlags colFl = cc.Move(moveVec);
        if (colFl == CollisionFlags.Sides)
        {
          ent_i.avatarMove.collideSides = true;
          ent_i.avatarMove.moveDirection = Vector3.zero;
        }
        else
        {
          ent_i.avatarMove.collideSides = false;
        }
      }
    }
    
  }
}
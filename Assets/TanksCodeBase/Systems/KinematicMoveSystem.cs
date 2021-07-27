using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  public class KinematicMoveSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> kinematicMovingGroup;

    public KinematicMoveSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      kinematicMovingGroup = contexts.game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.CharMoveSpeed,
          GameMatcher.KinematicMove,
          GameMatcher.Position,
          GameMatcher.View
        )
      );
    }

    public void Execute()
    {
      foreach (GameEntity ent_i in kinematicMovingGroup.GetEntities())
      {
        Vector3 moveVec = ent_i.kinematicMove.moveDirection * ent_i.charMoveSpeed.speed * Time.deltaTime;
        RaycastHit hit;
        float avatarRadius = 0.5f;
        Debug.DrawLine(ent_i.position.value, ent_i.position.value + moveVec + moveVec.normalized*avatarRadius, Color.green, 3f);

        if (Physics.SphereCast(ent_i.position.value,
                                1f,
                                ent_i.kinematicMove.moveDirection,
                                out hit,
                                ent_i.charMoveSpeed.speed * Time.deltaTime + avatarRadius))
        { 
          GameObject go = hit.transform.gameObject;
          if (go.GetEntityLink() != null)
          {
            GameEntity hitEntity = (GameEntity) go.GetEntityLink().entity;
            if (hitEntity != ent_i)
            {
              ent_i.kinematicMove.collideSides = true;
              ent_i.kinematicMove.moveDirection = Vector3.zero;
            }
            else
            {
              ent_i.kinematicMove.collideSides = false;
            }
          }
        }
        else
        {
          ent_i.kinematicMove.collideSides = false;
          ent_i.position.value += moveVec;
        }
      }
    }
  }
}
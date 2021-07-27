using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  /* Check if there is a player in line sight */
  public class AILineAimingSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> mobEnemyGroup;

    public AILineAimingSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      mobEnemyGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            // TODO do I need enemy tag?..
            GameMatcher.EnemyTag,
            GameMatcher.AILineAiming,
            GameMatcher.Position,
            GameMatcher.Rotation
          )
      );
    }

    public void Execute()
    {
      RaycastHit hit;
      foreach (GameEntity ent_i in mobEnemyGroup.GetEntities())
      {
        float dist = ent_i.aILineAiming.aimDistance;
        Vector3 dir = ent_i.rotation.value.eulerAngles;
        
        if (Physics.SphereCast(ent_i.position.value, 0.2f, dir, out hit, dist))
        {
          GameObject go = hit.transform.gameObject;
          if (go.GetEntityLink() != null)
          {
            GameEntity hitEntity = (GameEntity) go.GetEntityLink().entity;
            if (hitEntity.hasPlayer)
            {
              ent_i.aILineAiming.aimInDirectSight = true;
            }
            else
            {
              ent_i.aILineAiming.aimInDirectSight = false;
            }
          }
        }
      }
    }
    
  }
}
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  public class ProjectileImpactSystem : IExecuteSystem
  {
    private readonly GameContext gameContext;
    private readonly IGroup<GameEntity> bulletsGroup;

    public ProjectileImpactSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      bulletsGroup = contexts.game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.DirectionImpact, 
          GameMatcher.Move,
          GameMatcher.Position,
          GameMatcher.Rotation
          )
        );
    }

    public void Execute()
    {
      // TODO - this may be better during fixed update
      // TODO - bullet radius (big plasma vs. small lasers)
      RaycastHit hit;
      foreach (GameEntity ent_i in bulletsGroup.GetEntities())
      {
        float dist = ent_i.move.speed * Time.deltaTime;
        Vector3 dir = ent_i.move.direction;
        // TODO - do I need a sphere?..
        if (Physics.SphereCast(ent_i.position.value, 0.2f, dir, out hit, dist))
        {
          GameObject go = hit.transform.gameObject;
          // Stop the bullet
          // TODO better raycast layers and no dirty duck typing
          /*if (!go.GetComponent<CharacterController>())
          {
            
          }*/
          // TODO - don't remove, change flag and index that flag
          ent_i.RemoveMove();
          if (!ent_i.hasLifespan)
          {
            ent_i.AddLifespan(0.0f);  
          }
          else
          {
            ent_i.lifespan.timeToDestroy = 0.0f;
          }
          if (go.GetEntityLink() != null)
          {
            GameEntity hitEntity = (GameEntity) go.GetEntityLink().entity;
            if (hitEntity.hasDestructable)
            {
              // TODO - damage in SO
              hitEntity.destructable.damageTaken += 1;
            }
          }
        }
      }
    }
  }
}
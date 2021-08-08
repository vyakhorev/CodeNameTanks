
using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class ShootingSystem : IExecuteSystem
  {
    readonly IGroup<GameEntity> shootingGroup;
    readonly GameContext gameContext;
    
    public ShootingSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      shootingGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.Shooter, 
            GameMatcher.Position,
            GameMatcher.Rotation
          )
      );
    }

    public void Execute()
    {
      foreach (GameEntity ent_i in shootingGroup.GetEntities())
      {
        ent_i.shooter.timeFromShoot += Time.deltaTime;
        if (ent_i.shooter.timeFromShoot >= 1000f) { ent_i.shooter.timeFromShoot = 1000f; }
        
        //
          
        SOGunSetup gunSetup = ent_i.shooter.activeGunSetup;
        if (ent_i.shooter.activeGunSetup.coolDown <= ent_i.shooter.timeFromShoot &&
            ent_i.shooter.isActive == true)
        {
          // Reset cooldown
          ent_i.shooter.timeFromShoot = 0f;
          // Spawn a bullet 
          Vector3 gunPos = ent_i.position.value;
          Quaternion gunRot = ent_i.rotation.value;
          GameEntity bullet_i = gameContext.CreateEntity();
          bullet_i.AddMove(gunRot*Vector3.forward, 10);
          bullet_i.AddViewPrefab(ent_i.shooter.activeGunSetup.projectileParticle);
          bullet_i.AddLifespan(3f);
          bullet_i.AddPosition(gunPos);
          bullet_i.AddRotation(gunRot);
          bullet_i.AddDirectionImpact(1);
          
          // Spawn muzzle effect
          GameEntity muzzle_i = gameContext.CreateEntity();
          muzzle_i.AddViewPrefab(gunSetup.muzzleParticle);
          muzzle_i.AddLifespan(gunSetup.muzzleTime);
          muzzle_i.AddPosition(gunPos);
          muzzle_i.AddRotation(gunRot);
          
        }
      }
    }

  }
}
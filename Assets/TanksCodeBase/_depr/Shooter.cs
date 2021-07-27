using UnityEngine;

namespace TanksCodeBase
{
  public class Shooter : MonoBehaviour
  {
    private SOGunSetup activeGunSetup;
    private float timeFromShoot; 

    // Would be flexible to refactor this into a system
    public void Shoot()
    {
      if (timeFromShoot < this.activeGunSetup.coolDown)
      {
        // Not yet
        return;
      }
      timeFromShoot = 0f;

      if (activeGunSetup.projectileParticle)
      {
        GameEntity bullet = GameController.instance.gameContext.CreateEntity();
        bullet.AddMove(transform.rotation*Vector3.forward, 10);
        bullet.AddViewPrefab(activeGunSetup.projectileParticle);
        bullet.AddLifespan(3f);
        bullet.AddPosition(transform.position);
        bullet.AddRotation(transform.rotation);
        bullet.AddDirectionImpact(1);
      }

      if (activeGunSetup.muzzleParticle)
      {
        GameEntity muzzle = GameController.instance.gameContext.CreateEntity();
        muzzle.AddViewPrefab(activeGunSetup.muzzleParticle);
        muzzle.AddLifespan(activeGunSetup.muzzleTime);
        muzzle.AddPosition(transform.position);
        muzzle.AddRotation(transform.rotation);
      }
      
      // TODO: sounds (check PolygonSoundSpawn on missile prefab)
      
    }

    public void Update()
    {
      timeFromShoot += Time.deltaTime;
    }

    public void SetGunSetup(SOGunSetup chosenGunSetup)
    {
      activeGunSetup = chosenGunSetup;
    }
    
  }
}

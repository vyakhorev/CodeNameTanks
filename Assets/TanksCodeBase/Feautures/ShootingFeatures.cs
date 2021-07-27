namespace TanksCodeBase
{
  public class ShootingFeatures : Feature
  {
    public ShootingFeatures(Contexts contexts) : base ("Shooting features")
    {
      // Init systems
      Add(new AuthLevelObstacleSystem(contexts));
      
      // Update systems
      Add(new InputShootingSystem(contexts));
      Add(new ShootingSystem(contexts));
      Add(new MoveFreeSystem(contexts));
      Add(new ProjectileImpactSystem(contexts));
      Add(new FetchDestructionSystem(contexts));
    }
  }
}
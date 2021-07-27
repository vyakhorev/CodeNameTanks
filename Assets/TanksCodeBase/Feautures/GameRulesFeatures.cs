namespace TanksCodeBase
{
  public class GameRulesFeatures : Feature
  {
    public GameRulesFeatures(Contexts contexts) : base("Game rule features")
    {
      Add(new AuthSpawnPointsSystem(contexts));
      Add(new AuthRailroadSystem(contexts));
      Add(new AuthTrainSystem(contexts));
      
      Add(new SpawnPrefabSystem(contexts));
      Add(new LifespanSystem(contexts));
      Add(new SpawnAtPointsSystem(contexts));
    }
  }
}
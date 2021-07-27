namespace TanksCodeBase
{
  public class AIFeatures : Feature
  {
    public AIFeatures(Contexts contexts) : base("AI features")
    {
      Add(new AILineAimingSystem(contexts));
      Add(new AIConePerceptionSystem(contexts));
      Add(new AIShootingCommandSystem(contexts));
      Add(new AICommandExecutorSystem(contexts));
    }
  }
}
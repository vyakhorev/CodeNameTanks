namespace TanksCodeBase
{
  public class InputFeatures : Feature
  {
    public InputFeatures(Contexts contexts) : base("Input features")
    {
      Add(new InputSystem(contexts));
    }
  }
}
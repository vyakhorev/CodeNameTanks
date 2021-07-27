namespace TanksCodeBase
{
  public class ViewFeatures : Feature
  {
    public ViewFeatures(Contexts contexts) : base("View features")
    {
      Add(new AuthCameraTarget(contexts));
      Add(new FetchPositionRotationSystem(contexts));
      Add(new CameraTargetSystem(contexts));
    }
  }
}
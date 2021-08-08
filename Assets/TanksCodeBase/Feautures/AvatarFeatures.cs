namespace TanksCodeBase
{
  public class AvatarFeatures : Feature
  {
    public AvatarFeatures(Contexts contexts) : base("Avatar features")
    {
      Add(new SetupCharacterControllerSystem(contexts));
      Add(new TraceMovementSystem(contexts));
      Add(new SetupTraceMovementSystem(contexts));
      Add(new DestinationManagmentSystem(contexts));
      Add(new RandomDestinationSystem(contexts));
      Add(new DestinationFollowSystem(contexts));
      Add(new MilestoneMoveSystem(contexts));
      Add(new KinematicMoveSystem(contexts));
      Add(new AvatarMoveSystem(contexts));
      Add(new TeleportReactiveSystem(contexts));
      Add(new TeleportCleanupSystem(contexts));
      Add(new InputMoveSystem(contexts));
      Add(new RotationToMoveSystem(contexts));
    }
  }
}
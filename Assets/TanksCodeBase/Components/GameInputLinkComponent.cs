using Entitas;

namespace TanksCodeBase
{
  [Game, Input]
  public class GameInputLinkComponent : IComponent
  {
    // Tastes wrong but this works nice and still transparent
    public GameEntity gameEntity;
  }
}
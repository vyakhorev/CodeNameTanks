using Entitas;

namespace TanksCodeBase
{
  [Game]
  public class RandomWalkerComponent : IComponent
  {
    public bool isActive;
    public EnumDirections activeDirection;
  }
}
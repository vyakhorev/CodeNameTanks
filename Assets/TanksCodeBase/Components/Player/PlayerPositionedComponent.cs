using Entitas;

namespace TanksCodeBase
{
  /* Is the player positioned in the world */
  [Game]
  public class PlayerPositionedComponent : IComponent
  {
    public bool isPositioned;
  }
}
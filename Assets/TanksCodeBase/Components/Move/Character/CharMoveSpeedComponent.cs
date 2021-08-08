using Entitas;

namespace TanksCodeBase
{
  /* A speed of something that knows where to go (destination / navigation) */
  [Game]
  public class CharMoveSpeedComponent : IComponent
  {
    public float speed;
  }
}
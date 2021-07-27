using Entitas;

namespace TanksCodeBase
{
  [Game]
  public class AILineAimingComponent : IComponent
  {
    public bool aimInDirectSight;
    public float aimDistance;
  }
}
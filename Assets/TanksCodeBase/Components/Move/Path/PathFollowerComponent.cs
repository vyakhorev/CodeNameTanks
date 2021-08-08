using Entitas;

namespace TanksCodeBase
{
  /* This thing should move along a path - a railroad, for
   example. */
  [Game]
  public class PathFollowerComponent : IComponent
  {
    public int pathId;
    public int activePathStepId;
    public bool isActive;
  }
}
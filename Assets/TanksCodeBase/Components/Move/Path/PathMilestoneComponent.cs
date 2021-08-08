using System.Numerics;
using Entitas;

namespace TanksCodeBase
{
  /* Each path is "linked list" of PathMilestoneComponent.
   Train moves from a milestone to a milestone. */
  [Game]
  public class PathMilestoneComponent : IComponent
  {
    public int pathId;
    public int pathStepId;
    public bool isBlocked;
  }
}
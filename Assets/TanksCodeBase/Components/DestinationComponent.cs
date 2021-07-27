using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  /* Something that goes at destination in a straight-forward way. */
  [Game]
  public class DestinationComponent : IComponent
  {
    public bool isActive;
    public bool isReached;
    public bool isBlocked;
    public Vector3 destination;
    public Vector3 startPosition;
  }
}
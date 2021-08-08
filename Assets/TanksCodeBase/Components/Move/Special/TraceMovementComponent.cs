using UnityEngine;
using Entitas;

namespace TanksCodeBase
{
  [Game]
  public class TraceMovementComponent : IComponent
  {
    public Vector3 lastMovedVector;
    public Vector3 thisFrameMoveDirection;
    public Vector3 lastPosition;
    public bool movedLastFrame;
    public bool movingThisFrame;
  }
}
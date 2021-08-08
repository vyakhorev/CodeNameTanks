using UnityEngine;
using Entitas;

namespace TanksCodeBase
{
  [Game]
  public class KinematicMoveComponent : IComponent
  {
    public Vector3 moveDirection;
    public bool collideSides;
  }
}
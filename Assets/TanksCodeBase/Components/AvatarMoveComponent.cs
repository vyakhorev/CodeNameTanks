using UnityEngine;
using Entitas;

namespace TanksCodeBase
{
  [Game]
  public class AvatarMoveComponent : IComponent
  {
    public Vector3 moveDirection;
    public bool collideSides;
  }
}
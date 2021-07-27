using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  [Game]
  public class MoveComponent : IComponent
  {
    public Vector3 direction;
    public float speed;
  }
}
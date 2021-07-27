using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  [Game]
  public class PositionComponent : IComponent
  {
    public Vector3 value;
  }
}
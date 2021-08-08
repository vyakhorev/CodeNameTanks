using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  [Game]
  public class RotationComponent : IComponent
  {
    public Quaternion value;
  }
}
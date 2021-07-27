using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  [Game]
  public class AIConePerceptionComponent : IComponent
  {
    public Vector3 lookDirection;
    public float lookConeRadius;
    public float lookConeAngle;
  }
}
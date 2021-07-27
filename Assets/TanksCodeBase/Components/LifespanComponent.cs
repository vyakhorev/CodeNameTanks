using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  [Game]
  public class LifespanComponent : IComponent
  {
    public float timeToDestroy;
  }
}
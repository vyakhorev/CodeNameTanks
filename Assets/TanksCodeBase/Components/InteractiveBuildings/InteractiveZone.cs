using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  [Game]
  public class InteractiveZone : IComponent
  {
    public float waitedTime;
    public float timeToTrigger;
    public bool isTriggered;
    public float radius;
    public bool underExecution;
  }
}
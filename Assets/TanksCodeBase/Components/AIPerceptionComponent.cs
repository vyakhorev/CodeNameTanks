using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  [Game]
  public class AIPerceptionStateComponent : IComponent
  {
    public bool perceptionContactActive;
    public EnumPerceptionTypes perceptionType;
    public GameEntity spottedAim;
  }
}
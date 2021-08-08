using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class ShooterComponent : IComponent
  {
    public SOGunSetup activeGunSetup;
    public float timeFromShoot;
    public bool isActive;
  }
}
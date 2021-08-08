using UnityEngine;
using Entitas;

namespace TanksCodeBase
{
  [Game]
  public class TeleportComponent : IComponent
  {
    // TODO I think I should not stick with Vector2 
    public Vector2 teleportTo;
    public Quaternion teleportRotation;
    public bool isTeleported;
  }
}
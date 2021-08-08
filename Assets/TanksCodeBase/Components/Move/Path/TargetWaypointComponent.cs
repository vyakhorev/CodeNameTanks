using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  /* Keeps a way to a target (a character, for example)
   derived by navigation service (default Unity's A*). Refreshed each time
   target changes it's position. 
   Alternative to flow field calculation for smarter bosses. */
  [Game]
  public class TargetWaypointComponent : IComponent
  {
    public List<Vector3> waypoints;
    public float wayDistance;
    public GameObject sourceObject;
    public GameObject targetObject;
  }
}
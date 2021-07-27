using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  /* Enemy that uses target waypoint component to follow
   characters. */
  [Game]
  public class SpawnPointComponent : IComponent
  {
    // fixme - position is enough
    public float timeout;
    public float timeFromSpawn;
    public int maxSpawn;
    public int spawnedCnt;
    public bool isActive;
  }
}
using System;
using UnityEngine;

namespace TanksCodeBase
{
  /* Creates a spawn point entity */
  public class SpawnPointAuthoring : MonoBehaviour
  {
    [SerializeField] public GameObject spawnBuildingPrefab;
    [SerializeField] public float timeout;
    [SerializeField] public int maxSpawn;

    private void OnDrawGizmos()
    {
      Gizmos.DrawWireSphere(transform.position, 1f);
 
      Gizmos.color = Color.white;
    }
  }
}
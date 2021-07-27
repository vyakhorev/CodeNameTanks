using System.Collections.Generic;
using UnityEngine;

namespace TanksCodeBase
{
  public class RailRoadAuthoring : MonoBehaviour
  {
    [SerializeField] public List<GameObject> milepointsPath;
    [SerializeField] public GameObject pathPrefab;
    [SerializeField] public GameObject trainPrefab;
    [SerializeField] public int pathId;
    
    
    private void OnDrawGizmos()
    {
      foreach (GameObject go_i in milepointsPath)
      {
        Gizmos.DrawWireSphere(go_i.transform.position, 0.3f);
        Gizmos.color = Color.yellow;
      }
    }
  }
}

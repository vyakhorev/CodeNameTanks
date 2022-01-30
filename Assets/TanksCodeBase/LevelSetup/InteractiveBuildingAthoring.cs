using System;
using UnityEngine;

namespace TanksCodeBase
{
  public enum EnumBuildingTypes
  {
    LevelTeleporter,
    UpgradeFactory
  }
  
  public class InteractiveBuildingAthoring : MonoBehaviour
  {
    [SerializeField] public GameObject interactiveBuildingPrefab;
    [SerializeField] public EnumBuildingTypes buildingType;
    [SerializeField] public float timeToTrigger;
    [SerializeField] public float radius;

    private void OnDrawGizmos()
    {
      Gizmos.DrawWireSphere(transform.position, 1f);
      Gizmos.color = Color.magenta;
    }
    
  }
}
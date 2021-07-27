using UnityEngine;

namespace TanksCodeBase
{
  [CreateAssetMenu(fileName = "MobSetup", menuName = "CodeNameTanks/MobSetup", order = 2)]
  public class SOMobSetup : ScriptableObject
  {
    [SerializeField] public GameObject mobPrefab;
    [SerializeField] public SOGunSetup gunSetup;
  }
}
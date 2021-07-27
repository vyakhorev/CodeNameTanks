using System.Collections.Generic;
using UnityEngine;

namespace TanksCodeBase
{
  [CreateAssetMenu(fileName = "EnemyLogicSetup", menuName = "CodeNameTanks/EnemyLogicSetup", order = 3)]
  public class SOEnemyLogicSetup : ScriptableObject
  {
    [SerializeField] public List<SOMobSetup> possibleEnemySpawn;
  }
}
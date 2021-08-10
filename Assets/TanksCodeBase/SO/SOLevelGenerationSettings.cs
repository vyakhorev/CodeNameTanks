using UnityEngine;

namespace TanksCodeBase
{
  [CreateAssetMenu(fileName = "LevelGenerationSettings", menuName = "CodeNameTanks/", order = 3)]
  public class SOLevelGenerationSettings : ScriptableObject
  {
    [SerializeField] public Vector2Int levelSize;
  }
}
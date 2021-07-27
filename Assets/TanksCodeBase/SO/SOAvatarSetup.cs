using System.Collections.Generic;
using TanksCodeBase;
using UnityEngine;

namespace TanksCodeBase
{
  [CreateAssetMenu(fileName = "AvatarSetup", menuName = "CodeNameTanks/AvatarSetup", order = 1)]
  public class SOAvatarSetup : ScriptableObject
  {
    [SerializeField] public List<SOGunSetup> possibleGunSetups;
  }
}
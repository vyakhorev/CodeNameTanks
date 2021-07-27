using UnityEngine;

namespace TanksCodeBase
{
  [CreateAssetMenu(fileName = "GunSetup", menuName = "CodeNameTanks/GunSetup", order = 0)]
  public class SOGunSetup : ScriptableObject
  {
    // Particle effect
    [SerializeField] public GameObject impactParticle;
    [SerializeField] public GameObject projectileParticle;
    [SerializeField] public GameObject muzzleParticle;

    // Gameplay setup
    [SerializeField] public int hitDamage;
    [SerializeField] public float coolDown;
    [SerializeField] public float projectileSpeed;
    
    // Other effect setup
    [SerializeField] public float muzzleTime;

  }
}
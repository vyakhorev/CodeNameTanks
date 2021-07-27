using System;
using Cinemachine;
using TanksCodeBase;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Handles game state
 */

namespace TanksCodeBase
{
  public class GameInstance : MonoBehaviour
  {
    public static GameInstance instance;
    [SerializeField] public SOAvatarSetup AvatarsSetup;
    [SerializeField] public SOEnemyLogicSetup EnemyLogicSetup;
    [SerializeField] public GameObject PlayerSpawnPoint;
    [SerializeField] public GameObject CameraFollowObject;
    [SerializeField] public GameObject CMVirtCamera;
    
    private void Awake()
    {
      instance = this;
    }

    void Start()
    {
      ObjectPools objectPools = new ObjectPools();
      foreach (SOGunSetup gunStp in AvatarsSetup.possibleGunSetups)
      {
        objectPools.DefinePool(gunStp.impactParticle);
        objectPools.DefinePool(gunStp.muzzleParticle);
        objectPools.DefinePool(gunStp.projectileParticle);
      }
      foreach (SOMobSetup mobStp in EnemyLogicSetup.possibleEnemySpawn)
      {
        objectPools.DefinePool(mobStp.mobPrefab);
      }
      objectPools.InitiateAllPools();
    }
    
  }
}

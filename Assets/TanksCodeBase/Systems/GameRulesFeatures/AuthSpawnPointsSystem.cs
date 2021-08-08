using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  public class AuthSpawnPointsSystem : IInitializeSystem
  {
    readonly GameContext _game;

    public AuthSpawnPointsSystem(Contexts contexts)
    {
      _game = contexts.game;
    }
    
    public void Initialize()
    {
      SpawnPointAuthoring[] listToAuthor = MonoBehaviour.FindObjectsOfType<SpawnPointAuthoring>();
      foreach (SpawnPointAuthoring comp_i in listToAuthor)
      {
        GameEntity spwnPoint = GameController.instance.gameContext.CreateEntity();
        spwnPoint.AddViewPrefab(comp_i.spawnBuildingPrefab);
        spwnPoint.AddPosition(comp_i.transform.position);
        spwnPoint.AddRotation(comp_i.transform.rotation);
        spwnPoint.AddDestructable(3, 0, false);
        spwnPoint.AddSpawnPoint(newTimeout: comp_i.timeout, 
                                newTimeFromSpawn: 0f, 
                                newMaxSpawn: comp_i.maxSpawn, 
                                newSpawnedCnt: 0, 
                                newIsActive: true);
        comp_i.gameObject.Link(spwnPoint);
      }
    }
  }
}
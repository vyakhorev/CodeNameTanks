using System.Collections.Generic;
using UnityEngine;


namespace TanksCodeBase
{
  public class DynamicObjectPool
  {
    // TODO - cleanup unused objects and track usage
    private List<GameObject> objectPoolList;
    private GameObject objectType;
    // How long it takes before destroying every object above spawnAvrCnt.
    //private float unusedLifeSpan = 30f;
    // Time window used for spawnAvrCnt calculations
    //private float averageWindowSpan = 120f;
    // Initial and minimal spawned valuein
    private int spawnMinCnt = 10;
    // Average counter of gameObjects in use
    private int inUseAvrCnt;
    readonly Transform _objectPoolContainer;

    public DynamicObjectPool(GameObject objectType,
                             Transform poolContainer,
                             int spawnMinCnt = 5)
    {
      this.objectType = objectType;
      this.spawnMinCnt = spawnMinCnt;
      this._objectPoolContainer = poolContainer;
    }

    public void InitiatePool()
    {
      objectPoolList = new List<GameObject>();
      SpawnNew(spawnMinCnt);
    }

    public GameObject GetPooledObject()
    {
      // Try to find inactive object
      GameObject go = GetLastInactiveObject();
      if (go is null)
      {
        // Spawn new object for guaranteed return value
        go = SpawnNewGameObject();
        objectPoolList.Add(go);
      }
      return go;
    }

    private void SpawnNew(int howManyToSpawn)
    {
      for (int i = 0; i < howManyToSpawn; i++)
      {
        objectPoolList.Add(SpawnNewGameObject());
      }
    }

    private GameObject GetLastInactiveObject()
    {
      for (int i = 0; i < objectPoolList.Count; i++)
      {
        if (!objectPoolList[i].activeInHierarchy)
        {
          return objectPoolList[i];
        }
      }
      return null;
    }

    private GameObject SpawnNewGameObject()
    {
      GameObject go = GameObject.Instantiate(objectType, _objectPoolContainer);
      go.SetActive(false);
      return go;
    }

  }
}

using System.Collections;
using System.Collections.Generic;
using TanksCodeBase;
using UnityEngine;

namespace TanksCodeBase
{
  /* Manages multiple object pools 
   */
  public class ObjectPools
  {
    public static ObjectPools instance;
    private Dictionary<string,DynamicObjectPool> pools;
    readonly Transform _objectPoolContainer = new GameObject("Object pool container").transform;
    
    public ObjectPools()
    {
      instance = this;
      pools = new Dictionary<string, DynamicObjectPool>();
    }

    public void DefinePool(GameObject objectPrefab)
    {
      // "name" is not the best solution to handle object pools
      DynamicObjectPool newPool = new DynamicObjectPool(objectPrefab, _objectPoolContainer);
      pools.Add(objectPrefab.name, newPool);
    }

    public void InitiateAllPools()
    {
      foreach(KeyValuePair<string, DynamicObjectPool> entry in pools)
      {
        entry.Value.InitiatePool();
      }
    }

    public GameObject PoolObject(GameObject objectPrefab)
    {
      DynamicObjectPool pool;
      if (pools.TryGetValue(objectPrefab.name, out pool))
      {
        return pool.GetPooledObject();
      }
      
      DefinePool(objectPrefab);
      pool = pools[objectPrefab.name];
      pool.InitiatePool();
      return pool.GetPooledObject();
    }

    public void Inactivate(GameObject objectInstance,
                           float delayTime)
    {
      GameInstance.instance.StartCoroutine(
        InactivateAfterTime(objectInstance,
                                  delayTime)
        );
    }

    private IEnumerator InactivateAfterTime(GameObject objectInstance,
                                            float delayTime)
    {
      yield return new WaitForSeconds(delayTime);
      objectInstance.SetActive(false);
    }

  }
}
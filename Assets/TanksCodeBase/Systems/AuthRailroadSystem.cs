using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  /* Converts manually created rail road from gameobjects into entities */
  public class AuthRailroadSystem : IInitializeSystem
  {
    readonly GameContext gameContext;

    public AuthRailroadSystem(Contexts contexts)
    {
      gameContext = contexts.game;
    }
    
    public void Initialize()
    {
      RailRoadAuthoring[] listToAuthor = MonoBehaviour.FindObjectsOfType<RailRoadAuthoring>();
      foreach (RailRoadAuthoring comp_i in listToAuthor)
      {
        int pathStepId = 0;
        foreach (GameObject go_i in comp_i.milepointsPath)
        {
          GameEntity milepoint = gameContext.CreateEntity();
          milepoint.AddPathMilestone(comp_i.pathId, pathStepId, false);
          milepoint.AddPosition(go_i.transform.position);
          pathStepId++;
        }
      }
    }
  }
}


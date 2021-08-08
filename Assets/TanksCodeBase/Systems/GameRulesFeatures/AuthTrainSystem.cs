using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class AuthTrainSystem : IInitializeSystem
  {
    readonly GameContext gameContext;

    public AuthTrainSystem(Contexts contexts)
    {
      gameContext = contexts.game;
    }

    public void Initialize()
    {
      RailRoadAuthoring[] listToAuthor = MonoBehaviour.FindObjectsOfType<RailRoadAuthoring>();
      foreach (RailRoadAuthoring comp_i in listToAuthor)
      {
        Vector3 startPoint = comp_i.milepointsPath[0].gameObject.transform.position; 
        
        GameEntity train = gameContext.CreateEntity();
        train.AddPosition(startPoint + new Vector3(0,0.5f,0));
        train.AddRotation(Quaternion.identity);
        train.AddViewPrefab(comp_i.trainPrefab);
        train.AddDestructable(50, 0, false);
        train.AddPathFollower(newPathId: comp_i.pathId, newActivePathStepId: 0, newIsActive: true);
        // Kinematic movement - no character controller required.
        //train.AddAvatarMove(Vector3.zero, false, false);
        train.AddKinematicMove(Vector3.zero, false);
        train.AddDestination(false, false, false, Vector3.zero, Vector3.zero);
        train.AddCharMoveSpeed(1f);
        
      }
    }
  }
}
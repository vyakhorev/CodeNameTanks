using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class RandomDestinationSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> randomWalkersGroup;

    public RandomDestinationSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      randomWalkersGroup = gameContext.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.RandomWalker, 
          GameMatcher.Destination,
          GameMatcher.Position,
          GameMatcher.Rotation)
        );
    }

    public void Execute()
    {
      // TODO set active destination with a rule: rotate randomly and go for a distance
      foreach (GameEntity ent_i in randomWalkersGroup.GetEntities())
      {
        if (!ent_i.destination.isActive)
        {
          continue;
        }
        
        if (ent_i.destination.isReached||
            ent_i.destination.isBlocked)
        {
          // Pick up a new direction (different from a current one)
          EnumDirections rand_dir = (EnumDirections)Random.Range(0, 4);
          // Pick a distance
          Vector3 randDirVec;
          if (rand_dir == EnumDirections.east) randDirVec = Vector3.left;
          else if (rand_dir == EnumDirections.west) randDirVec = Vector3.right;
          else if (rand_dir == EnumDirections.north) randDirVec = Vector3.forward;
          else if (rand_dir == EnumDirections.south) randDirVec = Vector3.back;
          else randDirVec = Vector3.left;

          float travelDistance = (float)Random.Range(1, 5);
          
          // Check if destination is reachable
          if (Physics.SphereCast(ent_i.position.value, 0.5f, randDirVec.normalized, out RaycastHit hit, travelDistance))
          {
            GameObject go = hit.transform.gameObject;
            // Don't like this duck typing of characters
            if (!go.GetComponent<CharacterController>())
            {
              travelDistance = (ent_i.position.value - hit.transform.position).magnitude;
            }
          }
          
          ent_i.destination.startPosition = ent_i.position.value;
          ent_i.destination.destination = ent_i.position.value + randDirVec.normalized * travelDistance;
          Debug.DrawLine(
            ent_i.destination.startPosition,
            ent_i.destination.destination,
            Color.yellow,
            1f);
          
          // Activate. Would be deactivated when traveled far enough.
          ent_i.destination.isReached = false;
        }
        
      }
    }
  }
}
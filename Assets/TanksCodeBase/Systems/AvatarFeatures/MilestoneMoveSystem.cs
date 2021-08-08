using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  /* Moves trains and path-based attacking mobs. Character-based
   motion with a given path. Just setups next destination. */
  public class MilestoneMoveSystem : IExecuteSystem
  {
    private readonly GameContext context;
    private readonly IGroup<GameEntity> pathMoversGroup;
    private readonly IGroup<GameEntity> pathMilestones;

    public MilestoneMoveSystem(Contexts contexts)
    {
      context = contexts.game;
      // TODO get kinematics directly
      pathMoversGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.PathFollower,
            GameMatcher.Destination
          )
      );
      
      // TODO - index by pathId / stepId
      pathMilestones = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.PathMilestone,
            GameMatcher.Position
          )
      );

    }

    public void Execute()
    {
      // TODO still rubbish, I have to do this without destinations
      foreach (GameEntity ent_i in pathMoversGroup.GetEntities())
      {
        // TODO index isActive for destination
        if (ent_i.destination.isReached)
        {
          ent_i.pathFollower.activePathStepId++;
          int activeStep = ent_i.pathFollower.activePathStepId;
          int entPath = ent_i.pathFollower.pathId;
          // TODO - should be a way to query this better or just make a list
          // or cache in this system
          foreach (GameEntity path_i in pathMilestones.GetEntities())
          {
            if (path_i.pathMilestone.pathStepId == activeStep &&
                path_i.pathMilestone.pathId == entPath)
            {
              ent_i.destination.destination = path_i.position.value.xz();
              ent_i.destination.startPosition = ent_i.position.value.xz();
              ent_i.destination.isActive = true;
              ent_i.destination.isReached = false;
            }
          }
        }
      }
    }
    
  }
}
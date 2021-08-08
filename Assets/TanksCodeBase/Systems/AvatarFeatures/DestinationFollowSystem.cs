using Entitas;

namespace TanksCodeBase
{
  public class DestinationFollowSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> avatarsWithDestination;

    public DestinationFollowSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      
      avatarsWithDestination = gameContext.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Destination,
          GameMatcher.Position,
          GameMatcher.CharMoveSpeed
          ).AnyOf(
          GameMatcher.AvatarMove,
          GameMatcher.KinematicMove)
      );
    }
      
    public void Execute()
    {
      MoveAvatars();
    }
    
    private void MoveAvatars()
    {
      // TODO index destination.isActive
      foreach (GameEntity ent_i in avatarsWithDestination.GetEntities())
      {
        if (!ent_i.destination.isActive)
        {
          continue;
        }
        
        if (ent_i.hasAvatarMove)
        {
          if (ent_i.avatarMove.collideSides && ent_i.destination.isActive)
          {
            ent_i.destination.isBlocked = true;
          }
          else
          {
            ent_i.destination.isBlocked = false;
          }
        } 
        else if (ent_i.hasKinematicMove)
        {
          if (ent_i.kinematicMove.collideSides && ent_i.destination.isActive)
          {
            ent_i.destination.isBlocked = true;
          }
          else
          {
            ent_i.destination.isBlocked = false;
          }
        }

        float distanceTraveled = (ent_i.destination.startPosition.xz() - ent_i.position.value.xz()).magnitude;
        float distanceToTravel = (ent_i.destination.destination.xz() - ent_i.destination.startPosition.xz()).magnitude;
        if (distanceTraveled >= distanceToTravel)
        {
          ent_i.destination.isReached = true;
        }
        else
        {
          ent_i.destination.isReached = false;
        }
        
        if (!ent_i.destination.isBlocked&&
            !ent_i.destination.isReached)
        {
          // Mark avatar move component with direction
          if (ent_i.hasAvatarMove)
          {
            ent_i.avatarMove.moveDirection = (ent_i.destination.destination.xz() - ent_i.destination.startPosition.xz()).normalized;  
          }
          else if (ent_i.hasKinematicMove)
          {
            ent_i.kinematicMove.moveDirection = (ent_i.destination.destination.xz() - ent_i.destination.startPosition.xz()).normalized;  
          }
        }
      }
    }
  }
}
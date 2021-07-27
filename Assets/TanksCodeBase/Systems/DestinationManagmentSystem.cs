using Entitas;

namespace TanksCodeBase
{
  /* Manages "activity" flags on destination components. */
  public class DestinationManagmentSystem : IExecuteSystem
  {
    
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> destinationGroup;

    public DestinationManagmentSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      
      destinationGroup = gameContext.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Destination
        )
        );
    }
    
    public void Execute()
    {
      foreach (GameEntity ent_i in destinationGroup.GetEntities())
      {
        // TODO check if railroad is blocked or if enemy is captivated
        if (!ent_i.destination.isActive)
        {
          ent_i.destination.isActive = true;
        }
      }
    }
  }
}
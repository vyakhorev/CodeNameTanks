using Entitas;

namespace TanksCodeBase
{
  public class TeleportCleanupSystem : ICleanupSystem
  {
    readonly GameContext context;
    readonly IGroup<GameEntity> teleportEntities;
    
    public TeleportCleanupSystem(Contexts contexts)
    {
      context = contexts.game;
      teleportEntities = context.GetGroup(GameMatcher.Teleport);
    }
    
    public void Cleanup()
    {
      // group.GetEntities() always gives us an up to date list
      foreach (GameEntity ent_i in teleportEntities.GetEntities())
      {
        if (ent_i.teleport.isTeleported)
        {
          ent_i.RemoveTeleport();
        }
      }
    }
    
  }
}
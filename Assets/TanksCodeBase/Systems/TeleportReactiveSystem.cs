using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  /* Position player on the level */
  public class TeleportReactiveSystem : ReactiveSystem<GameEntity>
  {
    readonly GameContext gameContext;

    public TeleportReactiveSystem(Contexts contexts) : base(contexts.game)
    {
      gameContext = contexts.game;
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
      return context.CreateCollector(
        GameMatcher.
          AllOf(
            GameMatcher.Teleport,
            GameMatcher.Rotation,
            GameMatcher.Position,
            GameMatcher.View
          )
      );
    }
    
    protected override bool Filter(GameEntity entity)
    {
      return entity.hasTeleport && entity.hasAvatarMove && entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
      // TODO teleport player
      foreach (GameEntity ent_i in entities)
      { 
        if (ent_i.teleport.isTeleported == true) {continue;}
        
        // TODO reference CharacterController in avatar move
        // TODO teleport rotation
        CharacterController cc = ent_i.view.gameObject.GetComponent<CharacterController>();
        cc.enabled = false;
        Vector2 tp_xz = ent_i.teleport.teleportTo;
        Vector3 tp_xyz = new Vector3(tp_xz.x, -1, tp_xz.y);
        ent_i.view.gameObject.transform.position = tp_xyz;
        cc.enabled = true;
        
        ent_i.teleport.isTeleported = true;
      }
    }

  }
}
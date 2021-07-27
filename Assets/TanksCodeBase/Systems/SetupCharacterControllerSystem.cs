using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  public class SetupCharacterControllerSystem : ReactiveSystem<GameEntity>
  {
    readonly GameContext gameContext;
    
    public SetupCharacterControllerSystem(Contexts contexts) : base(contexts.game)
    {
      gameContext = contexts.game;
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
      return context.CreateCollector(
        GameMatcher.
          AllOf(
            GameMatcher.View,
            GameMatcher.AvatarMove
          ).
          NoneOf(
            GameMatcher.CharacterController
          )
      );
    }

    protected override bool Filter(GameEntity entity)
    {
      return entity.hasView && entity.hasAvatarMove && !entity.hasCharacterController;
    }

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity ent_i in entities)
      {
        CharacterController cc = ent_i.view.gameObject.GetComponent<CharacterController>();
        ent_i.AddCharacterController(cc);
      }
    }
    
  }
}
using Entitas;

namespace TanksCodeBase
{
  public class AIShootingCommandSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> mobEnemyGroup;
    
    public AIShootingCommandSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      mobEnemyGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.EnemyTag,
            GameMatcher.AIPerceptionState,
            GameMatcher.AIShootingCommandState
          )
      );
    }

    public void Execute()
    {
      foreach (GameEntity ent_i in mobEnemyGroup.GetEntities())
      {
        ent_i.aIShootingCommandState.doShoot = ent_i.aIPerceptionState.perceptionContactActive;
      }
    }
    
  }
}
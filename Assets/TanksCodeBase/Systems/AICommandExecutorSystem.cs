using Entitas;

namespace TanksCodeBase
{
  public class AICommandExecutorSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> mobEnemyShootingGroup;

    public AICommandExecutorSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      mobEnemyShootingGroup = contexts.game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.EnemyTag,
          GameMatcher.AIShootingCommandState,
          GameMatcher.Shooter
        )
      );
    }

    public void Execute()
    {
      foreach (GameEntity ent_i in mobEnemyShootingGroup.GetEntities())
      {
        ent_i.shooter.isActive = ent_i.aIShootingCommandState.doShoot;
      }
    }
  }
}
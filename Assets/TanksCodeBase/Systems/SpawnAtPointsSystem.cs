using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  /*
   * Creates new enemy at a random spawn point
   */
  public class SpawnAtPointsSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> spawnPointsGroup;

    public SpawnAtPointsSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      spawnPointsGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.SpawnPoint,
            GameMatcher.Position
          )
      );
    }

    public void Execute()
    {
      foreach (GameEntity ent_i in spawnPointsGroup.GetEntities())
      {
        ent_i.spawnPoint.timeFromSpawn += Time.deltaTime;
        if (ent_i.spawnPoint.spawnedCnt >= ent_i.spawnPoint.maxSpawn && !ent_i.hasLifespan)
        {
          ent_i.AddLifespan(0f);
          ent_i.spawnPoint.isActive = false;
          continue;
        }
        if (ent_i.spawnPoint.timeFromSpawn >= ent_i.spawnPoint.timeout && ent_i.spawnPoint.isActive)
        {
          ent_i.spawnPoint.timeFromSpawn = 0;
          
          // todo - no game instance
          SOMobSetup chosenMobSetup = GameInstance.instance.EnemyLogicSetup.possibleEnemySpawn[0];
          GameEntity enemyMob = gameContext.CreateEntity();
          enemyMob.AddRandomWalker(false, EnumDirections.west);
          enemyMob.isEnemyTag = true;
          enemyMob.AddDestination(false, false, false, Vector3.zero, Vector3.zero);
          // TODO fix vertical alignment and spawn point overlap
          enemyMob.AddPosition(ent_i.position.value + new Vector3(-1f,0.5f,0f));
          enemyMob.AddRotation(Quaternion.identity);
          enemyMob.AddCharMoveSpeed(1.5f);
          enemyMob.AddAvatarMove(Vector3.zero, false);
          enemyMob.AddDestructable(3, 0, false);
          
          enemyMob.AddShooter(chosenMobSetup.gunSetup, 0f, false);
          enemyMob.AddAIConePerception(Vector3.zero, 30f, 20f/360f*Mathf.PI);
          enemyMob.AddAIPerceptionState(false, EnumPerceptionTypes.Visual, null);
          enemyMob.AddAIShootingCommandState(false);
          
          enemyMob.AddViewPrefab(chosenMobSetup.mobPrefab);
          ent_i.spawnPoint.spawnedCnt += 1;
          
        }
        
      }
    }
  }
}
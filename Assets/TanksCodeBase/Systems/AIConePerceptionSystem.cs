using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  public class AIConePerceptionSystem : IExecuteSystem
  {
    readonly GameContext gameContext;
    readonly IGroup<GameEntity> mobEnemyGroup;
    readonly IGroup<GameEntity> playerGroup;
    
    public AIConePerceptionSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      mobEnemyGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.AIPerceptionState,
            GameMatcher.AIConePerception,
            GameMatcher.Position
          )
      );

      playerGroup = contexts.game.GetGroup(
        GameMatcher.
          AllOf(
            GameMatcher.Player,
            GameMatcher.Position
          )
      );

    }

    public void Execute()
    {
      //RaycastHit hit;
      foreach (GameEntity mob_i in mobEnemyGroup.GetEntities())
      {
        
        mob_i.aIConePerception.lookDirection =  mob_i.rotation.value * Vector3.forward;
        
        float r = mob_i.aIConePerception.lookConeRadius;
        float psi = mob_i.aIConePerception.lookConeAngle;
        Vector3 d = mob_i.aIConePerception.lookDirection;
        Vector3 x0 = mob_i.position.value.xz();

        var axis = new Vector3(0f, 1f, 0f);
        axis.Normalize();

        //var p1 = x0 + Quaternion.AngleAxis(-psi/2 * 360f/Mathf.PI, axis) * d * r;
        //var p2 = x0 + Quaternion.AngleAxis(psi/2 * 360f/Mathf.PI, axis) * d * r;

        mob_i.aIPerceptionState.perceptionType = EnumPerceptionTypes.Visual;
        mob_i.aIPerceptionState.spottedAim = null;
        mob_i.aIPerceptionState.perceptionContactActive = false;
        foreach (GameEntity plr_i in playerGroup.GetEntities())
        {
          // A possible target
          Vector3 x1 = plr_i.position.value.xz();
          if (Vector3.Distance(x0, x1) <= r)
          {
            float angleToPlayer = Mathf.Min(Vector3.Angle(d.normalized, (x1-x0).normalized), 90f);
            if (angleToPlayer <= psi*360f / (2f * Mathf.PI)  && (Vector3.Dot(d.normalized, (x1-x0).normalized)>=0))
            {
              // can see player
              mob_i.aIPerceptionState.perceptionType = EnumPerceptionTypes.Visual;
              mob_i.aIPerceptionState.spottedAim = plr_i;
              mob_i.aIPerceptionState.perceptionContactActive = true;
              
              // Found someone
              break;
            }
          }
        }

        /*if (mob_i.aIPerceptionState.perceptionContactActive == true)
        {
          Debug.DrawLine(x0, p1, Color.magenta);
          Debug.DrawLine(x0, p2, Color.magenta);  
        }
        else
        {
          Debug.DrawLine(x0, p1, Color.green);
          Debug.DrawLine(x0, p2, Color.green);
        }*/
        
        
      }
    }
    
  }
}
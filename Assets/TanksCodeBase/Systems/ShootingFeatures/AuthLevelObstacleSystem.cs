using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  public class AuthLevelObstacleSystem : IInitializeSystem
  {
    readonly GameContext gameContext;

    public AuthLevelObstacleSystem(Contexts contexts)
    {
      gameContext = contexts.game;
    }
    
    public void Initialize()
    {
      LevelObstacleAuthoring[] listToAuthor = MonoBehaviour.FindObjectsOfType<LevelObstacleAuthoring>();
      foreach (LevelObstacleAuthoring comp_i in listToAuthor)
      {
        GameEntity wall = gameContext.CreateEntity();
        wall.AddView(comp_i.gameObject);
        wall.AddPosition(comp_i.transform.position);
        wall.AddRotation(comp_i.transform.rotation);
        wall.AddDestructable(3, 0, false);
        comp_i.gameObject.Link(wall);
      }
    }
  }
}
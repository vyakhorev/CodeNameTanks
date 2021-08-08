using Entitas;

namespace TanksCodeBase
{
  /* Enemy that uses target waypoint component to follow
   characters. */
  [Game]
  public class NavigatableEnemyComponent : IComponent
  {
    //public GameObject activeTarget;
    public GameEntity activeTarget;
  }
}
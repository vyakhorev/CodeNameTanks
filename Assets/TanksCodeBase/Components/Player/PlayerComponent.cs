using Entitas;

namespace TanksCodeBase
{
  /* A character - the player's tank for example */
  [Game]
  public class PlayerComponent : IComponent
  {
    public int charNum;
    public bool isPlayer;
  }
}
using Entitas;

namespace TanksCodeBase
{
  [Game]
  public class DestructableComponent : IComponent
  {
    public int damageMax;
    public int damageTaken;
    public bool isDestroyed;
  }
}
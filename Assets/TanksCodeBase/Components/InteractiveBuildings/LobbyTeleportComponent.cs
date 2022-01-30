using Entitas;

namespace TanksCodeBase
{
  public enum EnumLevelTypes
  {
    Versus,
    Cooperative,
    Tutorial
  }
  
  [Game]
  public class LobbyTeleportComponent : IComponent
  {
    public EnumLevelTypes levelType;
  }
}
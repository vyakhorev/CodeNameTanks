using Entitas;

namespace TanksCodeBase
{
  [Game] 
  public class AIMobStateComponent : IComponent
  {
    public EnumBotStates botState;
  }
}
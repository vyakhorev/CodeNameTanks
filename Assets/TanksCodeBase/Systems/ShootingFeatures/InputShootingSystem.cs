using Entitas;

namespace TanksCodeBase
{
  public class InputShootingSystem : IExecuteSystem
  {
    readonly IGroup<InputEntity> inputMoveGroup;
    readonly GameContext gameContext;

    public InputShootingSystem(Contexts contexts)
    {
      gameContext = contexts.game;
      inputMoveGroup = contexts.input.GetGroup(
        InputMatcher.AllOf(
          InputMatcher.Input,
          InputMatcher.GameInputLink
        )
      );
    }

    public void Execute()
    {
      foreach (InputEntity inp_i in inputMoveGroup.GetEntities())
      {
        GameEntity gm_i = inp_i.gameInputLink.gameEntity;
        if (gm_i.hasShooter)
        {
          if (inp_i.input.fired)
          {
            gm_i.shooter.isActive = true;  
          }
          else
          {
            gm_i.shooter.isActive = false;
          }
        }
      }
    }
    
  }
}
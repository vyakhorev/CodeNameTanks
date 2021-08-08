using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  
  public class InputMoveSystem : IExecuteSystem
  {
    readonly IGroup<InputEntity> inputMoveGroup;
    public InputMoveSystem(Contexts contexts)
    {
      //inputContext = contexts.input;
      inputMoveGroup = contexts.input.GetGroup(
        InputMatcher.
          AllOf(
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
        if (gm_i.hasAvatarMove)
        {
          gm_i.avatarMove.moveDirection = new Vector3(inp_i.input.move.x, 0, inp_i.input.move.y);
        }
      }
    }
    
  }
}
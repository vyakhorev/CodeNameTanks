using Entitas;
using UnityEngine;

namespace TanksCodeBase
{
  [Input]
  public class InputComponent : IComponent
  {
    public Vector2 move;
    public bool jumped;
    public bool fired;
  }
}
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace TanksCodeBase
{
  public class AuthCameraTarget : IInitializeSystem
  {
    readonly GameContext gameContext;
    
    public AuthCameraTarget(Contexts contexts)
    {
      gameContext = contexts.game;
    }
    
    public void Initialize()
    {
      GameEntity cameraTarget = gameContext.CreateEntity();
      cameraTarget.AddView(GameInstance.instance.CameraFollowObject);
      cameraTarget.AddPosition(cameraTarget.view.gameObject.transform.position);
      cameraTarget.AddRotation(Quaternion.identity);
      cameraTarget.AddCameraTarget(GameInstance.instance.CameraFollowObject);
      GameInstance.instance.CameraFollowObject.Link(cameraTarget);
    }
    
  }
}
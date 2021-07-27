//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.CameraTargetComponent cameraTarget { get { return (TanksCodeBase.CameraTargetComponent)GetComponent(GameComponentsLookup.CameraTarget); } }
    public bool hasCameraTarget { get { return HasComponent(GameComponentsLookup.CameraTarget); } }

    public void AddCameraTarget(UnityEngine.GameObject newCmTargetGameObject) {
        var index = GameComponentsLookup.CameraTarget;
        var component = (TanksCodeBase.CameraTargetComponent)CreateComponent(index, typeof(TanksCodeBase.CameraTargetComponent));
        component.cmTargetGameObject = newCmTargetGameObject;
        AddComponent(index, component);
    }

    public void ReplaceCameraTarget(UnityEngine.GameObject newCmTargetGameObject) {
        var index = GameComponentsLookup.CameraTarget;
        var component = (TanksCodeBase.CameraTargetComponent)CreateComponent(index, typeof(TanksCodeBase.CameraTargetComponent));
        component.cmTargetGameObject = newCmTargetGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveCameraTarget() {
        RemoveComponent(GameComponentsLookup.CameraTarget);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCameraTarget;

    public static Entitas.IMatcher<GameEntity> CameraTarget {
        get {
            if (_matcherCameraTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CameraTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCameraTarget = matcher;
            }

            return _matcherCameraTarget;
        }
    }
}
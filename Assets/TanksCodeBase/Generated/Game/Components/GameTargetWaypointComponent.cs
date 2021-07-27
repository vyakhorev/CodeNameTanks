//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.TargetWaypointComponent targetWaypoint { get { return (TanksCodeBase.TargetWaypointComponent)GetComponent(GameComponentsLookup.TargetWaypoint); } }
    public bool hasTargetWaypoint { get { return HasComponent(GameComponentsLookup.TargetWaypoint); } }

    public void AddTargetWaypoint(System.Collections.Generic.List<UnityEngine.Vector3> newWaypoints, float newWayDistance, UnityEngine.GameObject newSourceObject, UnityEngine.GameObject newTargetObject) {
        var index = GameComponentsLookup.TargetWaypoint;
        var component = (TanksCodeBase.TargetWaypointComponent)CreateComponent(index, typeof(TanksCodeBase.TargetWaypointComponent));
        component.waypoints = newWaypoints;
        component.wayDistance = newWayDistance;
        component.sourceObject = newSourceObject;
        component.targetObject = newTargetObject;
        AddComponent(index, component);
    }

    public void ReplaceTargetWaypoint(System.Collections.Generic.List<UnityEngine.Vector3> newWaypoints, float newWayDistance, UnityEngine.GameObject newSourceObject, UnityEngine.GameObject newTargetObject) {
        var index = GameComponentsLookup.TargetWaypoint;
        var component = (TanksCodeBase.TargetWaypointComponent)CreateComponent(index, typeof(TanksCodeBase.TargetWaypointComponent));
        component.waypoints = newWaypoints;
        component.wayDistance = newWayDistance;
        component.sourceObject = newSourceObject;
        component.targetObject = newTargetObject;
        ReplaceComponent(index, component);
    }

    public void RemoveTargetWaypoint() {
        RemoveComponent(GameComponentsLookup.TargetWaypoint);
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

    static Entitas.IMatcher<GameEntity> _matcherTargetWaypoint;

    public static Entitas.IMatcher<GameEntity> TargetWaypoint {
        get {
            if (_matcherTargetWaypoint == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TargetWaypoint);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTargetWaypoint = matcher;
            }

            return _matcherTargetWaypoint;
        }
    }
}

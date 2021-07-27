//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.DestinationComponent destination { get { return (TanksCodeBase.DestinationComponent)GetComponent(GameComponentsLookup.Destination); } }
    public bool hasDestination { get { return HasComponent(GameComponentsLookup.Destination); } }

    public void AddDestination(bool newIsActive, bool newIsReached, bool newIsBlocked, UnityEngine.Vector3 newDestination, UnityEngine.Vector3 newStartPosition) {
        var index = GameComponentsLookup.Destination;
        var component = (TanksCodeBase.DestinationComponent)CreateComponent(index, typeof(TanksCodeBase.DestinationComponent));
        component.isActive = newIsActive;
        component.isReached = newIsReached;
        component.isBlocked = newIsBlocked;
        component.destination = newDestination;
        component.startPosition = newStartPosition;
        AddComponent(index, component);
    }

    public void ReplaceDestination(bool newIsActive, bool newIsReached, bool newIsBlocked, UnityEngine.Vector3 newDestination, UnityEngine.Vector3 newStartPosition) {
        var index = GameComponentsLookup.Destination;
        var component = (TanksCodeBase.DestinationComponent)CreateComponent(index, typeof(TanksCodeBase.DestinationComponent));
        component.isActive = newIsActive;
        component.isReached = newIsReached;
        component.isBlocked = newIsBlocked;
        component.destination = newDestination;
        component.startPosition = newStartPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveDestination() {
        RemoveComponent(GameComponentsLookup.Destination);
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

    static Entitas.IMatcher<GameEntity> _matcherDestination;

    public static Entitas.IMatcher<GameEntity> Destination {
        get {
            if (_matcherDestination == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Destination);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDestination = matcher;
            }

            return _matcherDestination;
        }
    }
}

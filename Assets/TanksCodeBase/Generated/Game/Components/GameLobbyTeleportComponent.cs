//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.LobbyTeleportComponent lobbyTeleport { get { return (TanksCodeBase.LobbyTeleportComponent)GetComponent(GameComponentsLookup.LobbyTeleport); } }
    public bool hasLobbyTeleport { get { return HasComponent(GameComponentsLookup.LobbyTeleport); } }

    public void AddLobbyTeleport(float newWaitedTime) {
        var index = GameComponentsLookup.LobbyTeleport;
        var component = (TanksCodeBase.LobbyTeleportComponent)CreateComponent(index, typeof(TanksCodeBase.LobbyTeleportComponent));
        component.waitedTime = newWaitedTime;
        AddComponent(index, component);
    }

    public void ReplaceLobbyTeleport(float newWaitedTime) {
        var index = GameComponentsLookup.LobbyTeleport;
        var component = (TanksCodeBase.LobbyTeleportComponent)CreateComponent(index, typeof(TanksCodeBase.LobbyTeleportComponent));
        component.waitedTime = newWaitedTime;
        ReplaceComponent(index, component);
    }

    public void RemoveLobbyTeleport() {
        RemoveComponent(GameComponentsLookup.LobbyTeleport);
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

    static Entitas.IMatcher<GameEntity> _matcherLobbyTeleport;

    public static Entitas.IMatcher<GameEntity> LobbyTeleport {
        get {
            if (_matcherLobbyTeleport == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LobbyTeleport);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLobbyTeleport = matcher;
            }

            return _matcherLobbyTeleport;
        }
    }
}
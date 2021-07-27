//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.PlayerComponent player { get { return (TanksCodeBase.PlayerComponent)GetComponent(GameComponentsLookup.Player); } }
    public bool hasPlayer { get { return HasComponent(GameComponentsLookup.Player); } }

    public void AddPlayer(int newCharNum, bool newIsPlayer) {
        var index = GameComponentsLookup.Player;
        var component = (TanksCodeBase.PlayerComponent)CreateComponent(index, typeof(TanksCodeBase.PlayerComponent));
        component.charNum = newCharNum;
        component.isPlayer = newIsPlayer;
        AddComponent(index, component);
    }

    public void ReplacePlayer(int newCharNum, bool newIsPlayer) {
        var index = GameComponentsLookup.Player;
        var component = (TanksCodeBase.PlayerComponent)CreateComponent(index, typeof(TanksCodeBase.PlayerComponent));
        component.charNum = newCharNum;
        component.isPlayer = newIsPlayer;
        ReplaceComponent(index, component);
    }

    public void RemovePlayer() {
        RemoveComponent(GameComponentsLookup.Player);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayer;

    public static Entitas.IMatcher<GameEntity> Player {
        get {
            if (_matcherPlayer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Player);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayer = matcher;
            }

            return _matcherPlayer;
        }
    }
}

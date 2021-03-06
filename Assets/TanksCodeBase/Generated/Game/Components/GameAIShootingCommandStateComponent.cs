//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.AIShootingCommandStateComponent aIShootingCommandState { get { return (TanksCodeBase.AIShootingCommandStateComponent)GetComponent(GameComponentsLookup.AIShootingCommandState); } }
    public bool hasAIShootingCommandState { get { return HasComponent(GameComponentsLookup.AIShootingCommandState); } }

    public void AddAIShootingCommandState(bool newDoShoot) {
        var index = GameComponentsLookup.AIShootingCommandState;
        var component = (TanksCodeBase.AIShootingCommandStateComponent)CreateComponent(index, typeof(TanksCodeBase.AIShootingCommandStateComponent));
        component.doShoot = newDoShoot;
        AddComponent(index, component);
    }

    public void ReplaceAIShootingCommandState(bool newDoShoot) {
        var index = GameComponentsLookup.AIShootingCommandState;
        var component = (TanksCodeBase.AIShootingCommandStateComponent)CreateComponent(index, typeof(TanksCodeBase.AIShootingCommandStateComponent));
        component.doShoot = newDoShoot;
        ReplaceComponent(index, component);
    }

    public void RemoveAIShootingCommandState() {
        RemoveComponent(GameComponentsLookup.AIShootingCommandState);
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

    static Entitas.IMatcher<GameEntity> _matcherAIShootingCommandState;

    public static Entitas.IMatcher<GameEntity> AIShootingCommandState {
        get {
            if (_matcherAIShootingCommandState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AIShootingCommandState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAIShootingCommandState = matcher;
            }

            return _matcherAIShootingCommandState;
        }
    }
}

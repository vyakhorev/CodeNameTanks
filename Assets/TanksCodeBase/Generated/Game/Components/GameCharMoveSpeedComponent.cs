//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.CharMoveSpeedComponent charMoveSpeed { get { return (TanksCodeBase.CharMoveSpeedComponent)GetComponent(GameComponentsLookup.CharMoveSpeed); } }
    public bool hasCharMoveSpeed { get { return HasComponent(GameComponentsLookup.CharMoveSpeed); } }

    public void AddCharMoveSpeed(float newSpeed) {
        var index = GameComponentsLookup.CharMoveSpeed;
        var component = (TanksCodeBase.CharMoveSpeedComponent)CreateComponent(index, typeof(TanksCodeBase.CharMoveSpeedComponent));
        component.speed = newSpeed;
        AddComponent(index, component);
    }

    public void ReplaceCharMoveSpeed(float newSpeed) {
        var index = GameComponentsLookup.CharMoveSpeed;
        var component = (TanksCodeBase.CharMoveSpeedComponent)CreateComponent(index, typeof(TanksCodeBase.CharMoveSpeedComponent));
        component.speed = newSpeed;
        ReplaceComponent(index, component);
    }

    public void RemoveCharMoveSpeed() {
        RemoveComponent(GameComponentsLookup.CharMoveSpeed);
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

    static Entitas.IMatcher<GameEntity> _matcherCharMoveSpeed;

    public static Entitas.IMatcher<GameEntity> CharMoveSpeed {
        get {
            if (_matcherCharMoveSpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CharMoveSpeed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharMoveSpeed = matcher;
            }

            return _matcherCharMoveSpeed;
        }
    }
}
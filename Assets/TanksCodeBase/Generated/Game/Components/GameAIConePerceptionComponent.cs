//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.AIConePerceptionComponent aIConePerception { get { return (TanksCodeBase.AIConePerceptionComponent)GetComponent(GameComponentsLookup.AIConePerception); } }
    public bool hasAIConePerception { get { return HasComponent(GameComponentsLookup.AIConePerception); } }

    public void AddAIConePerception(UnityEngine.Vector3 newLookDirection, float newLookConeRadius, float newLookConeAngle) {
        var index = GameComponentsLookup.AIConePerception;
        var component = (TanksCodeBase.AIConePerceptionComponent)CreateComponent(index, typeof(TanksCodeBase.AIConePerceptionComponent));
        component.lookDirection = newLookDirection;
        component.lookConeRadius = newLookConeRadius;
        component.lookConeAngle = newLookConeAngle;
        AddComponent(index, component);
    }

    public void ReplaceAIConePerception(UnityEngine.Vector3 newLookDirection, float newLookConeRadius, float newLookConeAngle) {
        var index = GameComponentsLookup.AIConePerception;
        var component = (TanksCodeBase.AIConePerceptionComponent)CreateComponent(index, typeof(TanksCodeBase.AIConePerceptionComponent));
        component.lookDirection = newLookDirection;
        component.lookConeRadius = newLookConeRadius;
        component.lookConeAngle = newLookConeAngle;
        ReplaceComponent(index, component);
    }

    public void RemoveAIConePerception() {
        RemoveComponent(GameComponentsLookup.AIConePerception);
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

    static Entitas.IMatcher<GameEntity> _matcherAIConePerception;

    public static Entitas.IMatcher<GameEntity> AIConePerception {
        get {
            if (_matcherAIConePerception == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AIConePerception);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAIConePerception = matcher;
            }

            return _matcherAIConePerception;
        }
    }
}

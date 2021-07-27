//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.ViewPrefabComponent viewPrefab { get { return (TanksCodeBase.ViewPrefabComponent)GetComponent(GameComponentsLookup.ViewPrefab); } }
    public bool hasViewPrefab { get { return HasComponent(GameComponentsLookup.ViewPrefab); } }

    public void AddViewPrefab(UnityEngine.GameObject newPrefabGameObject) {
        var index = GameComponentsLookup.ViewPrefab;
        var component = (TanksCodeBase.ViewPrefabComponent)CreateComponent(index, typeof(TanksCodeBase.ViewPrefabComponent));
        component.prefabGameObject = newPrefabGameObject;
        AddComponent(index, component);
    }

    public void ReplaceViewPrefab(UnityEngine.GameObject newPrefabGameObject) {
        var index = GameComponentsLookup.ViewPrefab;
        var component = (TanksCodeBase.ViewPrefabComponent)CreateComponent(index, typeof(TanksCodeBase.ViewPrefabComponent));
        component.prefabGameObject = newPrefabGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveViewPrefab() {
        RemoveComponent(GameComponentsLookup.ViewPrefab);
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

    static Entitas.IMatcher<GameEntity> _matcherViewPrefab;

    public static Entitas.IMatcher<GameEntity> ViewPrefab {
        get {
            if (_matcherViewPrefab == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewPrefab);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewPrefab = matcher;
            }

            return _matcherViewPrefab;
        }
    }
}

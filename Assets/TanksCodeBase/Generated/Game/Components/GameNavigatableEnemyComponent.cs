//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TanksCodeBase.NavigatableEnemyComponent navigatableEnemy { get { return (TanksCodeBase.NavigatableEnemyComponent)GetComponent(GameComponentsLookup.NavigatableEnemy); } }
    public bool hasNavigatableEnemy { get { return HasComponent(GameComponentsLookup.NavigatableEnemy); } }

    public void AddNavigatableEnemy(GameEntity newActiveTarget) {
        var index = GameComponentsLookup.NavigatableEnemy;
        var component = (TanksCodeBase.NavigatableEnemyComponent)CreateComponent(index, typeof(TanksCodeBase.NavigatableEnemyComponent));
        component.activeTarget = newActiveTarget;
        AddComponent(index, component);
    }

    public void ReplaceNavigatableEnemy(GameEntity newActiveTarget) {
        var index = GameComponentsLookup.NavigatableEnemy;
        var component = (TanksCodeBase.NavigatableEnemyComponent)CreateComponent(index, typeof(TanksCodeBase.NavigatableEnemyComponent));
        component.activeTarget = newActiveTarget;
        ReplaceComponent(index, component);
    }

    public void RemoveNavigatableEnemy() {
        RemoveComponent(GameComponentsLookup.NavigatableEnemy);
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

    static Entitas.IMatcher<GameEntity> _matcherNavigatableEnemy;

    public static Entitas.IMatcher<GameEntity> NavigatableEnemy {
        get {
            if (_matcherNavigatableEnemy == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NavigatableEnemy);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNavigatableEnemy = matcher;
            }

            return _matcherNavigatableEnemy;
        }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public TanksCodeBase.GameInputLinkComponent gameInputLink { get { return (TanksCodeBase.GameInputLinkComponent)GetComponent(InputComponentsLookup.GameInputLink); } }
    public bool hasGameInputLink { get { return HasComponent(InputComponentsLookup.GameInputLink); } }

    public void AddGameInputLink(GameEntity newGameEntity) {
        var index = InputComponentsLookup.GameInputLink;
        var component = (TanksCodeBase.GameInputLinkComponent)CreateComponent(index, typeof(TanksCodeBase.GameInputLinkComponent));
        component.gameEntity = newGameEntity;
        AddComponent(index, component);
    }

    public void ReplaceGameInputLink(GameEntity newGameEntity) {
        var index = InputComponentsLookup.GameInputLink;
        var component = (TanksCodeBase.GameInputLinkComponent)CreateComponent(index, typeof(TanksCodeBase.GameInputLinkComponent));
        component.gameEntity = newGameEntity;
        ReplaceComponent(index, component);
    }

    public void RemoveGameInputLink() {
        RemoveComponent(InputComponentsLookup.GameInputLink);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity : IGameInputLinkEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherGameInputLink;

    public static Entitas.IMatcher<InputEntity> GameInputLink {
        get {
            if (_matcherGameInputLink == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.GameInputLink);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherGameInputLink = matcher;
            }

            return _matcherGameInputLink;
        }
    }
}

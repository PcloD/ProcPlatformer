//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GamePlatformer.Model.GameComponents.SizeComponent size { get { return (GamePlatformer.Model.GameComponents.SizeComponent)GetComponent(GameComponentsLookup.Size); } }
    public bool hasSize { get { return HasComponent(GameComponentsLookup.Size); } }

    public void AddSize(int newX, int newY) {
        var index = GameComponentsLookup.Size;
        var component = CreateComponent<GamePlatformer.Model.GameComponents.SizeComponent>(index);
        component.x = newX;
        component.y = newY;
        AddComponent(index, component);
    }

    public void ReplaceSize(int newX, int newY) {
        var index = GameComponentsLookup.Size;
        var component = CreateComponent<GamePlatformer.Model.GameComponents.SizeComponent>(index);
        component.x = newX;
        component.y = newY;
        ReplaceComponent(index, component);
    }

    public void RemoveSize() {
        RemoveComponent(GameComponentsLookup.Size);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSize;

    public static Entitas.IMatcher<GameEntity> Size {
        get {
            if (_matcherSize == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Size);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSize = matcher;
            }

            return _matcherSize;
        }
    }
}
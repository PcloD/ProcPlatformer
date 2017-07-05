//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GamePlatformer.Model.GameComponents.AvatarComponent avatar { get { return (GamePlatformer.Model.GameComponents.AvatarComponent)GetComponent(GameComponentsLookup.Avatar); } }
    public bool hasAvatar { get { return HasComponent(GameComponentsLookup.Avatar); } }

    public void AddAvatar(string newId) {
        var index = GameComponentsLookup.Avatar;
        var component = CreateComponent<GamePlatformer.Model.GameComponents.AvatarComponent>(index);
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceAvatar(string newId) {
        var index = GameComponentsLookup.Avatar;
        var component = CreateComponent<GamePlatformer.Model.GameComponents.AvatarComponent>(index);
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveAvatar() {
        RemoveComponent(GameComponentsLookup.Avatar);
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

    static Entitas.IMatcher<GameEntity> _matcherAvatar;

    public static Entitas.IMatcher<GameEntity> Avatar {
        get {
            if (_matcherAvatar == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Avatar);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAvatar = matcher;
            }

            return _matcherAvatar;
        }
    }
}

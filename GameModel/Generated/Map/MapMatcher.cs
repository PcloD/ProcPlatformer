//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MapMatcher {

    public static Entitas.IAllOfMatcher<MapEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<MapEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<MapEntity> AllOf(params Entitas.IMatcher<MapEntity>[] matchers) {
          return Entitas.Matcher<MapEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<MapEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<MapEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<MapEntity> AnyOf(params Entitas.IMatcher<MapEntity>[] matchers) {
          return Entitas.Matcher<MapEntity>.AnyOf(matchers);
    }
}

using Entitas;
using GamePlatformer.Model.Tiles;

namespace GamePlatformer.Model.GameComponents
{
    [Game]
    public sealed class TileComponent : IComponent
    {
        public TileDefinition definition;

        public override string ToString()
        {
            return $"Tile({definition.id})";
        }
    }
}

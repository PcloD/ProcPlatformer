using Entitas;
using Entitas.CodeGeneration.Attributes;
using GamePlatformer.Model.Utils;

namespace GamePlatformer.Model.GameComponents
{
    [Map, Unique]
    public sealed class MapComponent : IComponent
    {
        public IntVector2 sizeInTiles;

        public TilePosition startTilePosition;

        public TilePosition endTilePosition;

        public override string ToString()
        {
            return $"Map - Size({sizeInTiles}) - StartPosition({startTilePosition}) - EndPosition({endTilePosition})";
        }
    }
}

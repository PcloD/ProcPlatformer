using Entitas;
using GamePlatformer.Model.Utils;
using Entitas.CodeGeneration.Attributes;

namespace GamePlatformer.Model.GameComponents
{
    [Game]
    public sealed class TilePositionComponent : IComponent
    {
        public const int TileSize = 32;

        [EntityIndex]
        public TilePosition tilePosition;

        public IntVector2 TopLeftWorldPosition
        {
            get
            {
                return TransformTilePositionToTopLeftWorldPosition(tilePosition);
            }
        }

        public IntVector2 CenterWorldPosition
        {
            get
            {
                return TransformTilePositionToWorldCenteredPosition(tilePosition);
            }
        }

        public override string ToString()
        {
            return $"TilePosition({tilePosition})";
        }

        static public IntVector2 TransformTilePositionToTopLeftWorldPosition(TilePosition tilePosition)
        {
            return new IntVector2(tilePosition.x * TileSize + TileSize / 2, tilePosition.y * TileSize + TileSize / 2);
        }

        static public IntVector2 TransformTilePositionToWorldCenteredPosition(TilePosition tilePosition)
        {
            return new IntVector2(tilePosition.x * TileSize + TileSize / 2, tilePosition.y * TileSize + TileSize / 2);
        }

    }
}

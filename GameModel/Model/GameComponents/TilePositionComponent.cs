using Entitas;
using GamePlatformer.Model.Utils;
using Entitas.CodeGeneration.Attributes;
using System;

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
                return TransformTilePositionToCenteredWorldPosition(tilePosition);
            }
        }

        public IntVector2 BottomMiddleWorldPosition
        {
            get
            {
                return TransformTilePositionToBottomMiddleWorldPosition(tilePosition);
            }
        }

        public override string ToString()
        {
            return $"TilePosition({tilePosition})";
        }

        static public IntVector2 TransformTilePositionToTopLeftWorldPosition(TilePosition tilePosition)
        {
            return new IntVector2(tilePosition.x * TileSize, tilePosition.y * TileSize);
        }

        static public IntVector2 TransformTilePositionToCenteredWorldPosition(TilePosition tilePosition)
        {
            return new IntVector2(tilePosition.x * TileSize + TileSize / 2, tilePosition.y * TileSize + TileSize / 2);
        }

        static public IntVector2 TransformTilePositionToBottomMiddleWorldPosition(TilePosition tilePosition)
        {
            return new IntVector2(tilePosition.x * TileSize + TileSize / 2, tilePosition.y * TileSize + TileSize - 1);
        }

        static public TilePosition TransformWorldPositionToTilePosition(IntVector2 worldPosition)
        {
            return new TilePosition(worldPosition.x / TileSize, worldPosition.y / TileSize);
        }
    }
}

using GamePlatformer.Model.GameComponents;
using System;

namespace GamePlatformer.Model.Utils
{
    public struct TilePosition : IEquatable<TilePosition>
    {
        public int x;
        public int y;

        public TilePosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(TilePosition other)
        {
            return other.x == x && other.y == y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType() || obj.GetHashCode() != GetHashCode())
            {
                return false;
            }

            var other = (IntVector2)obj;
            return other.x == x && other.y == y;
        }

        public IntVector2 ToTopLeftWorldPosition()
        {
            return TilePositionComponent.TransformTilePositionToTopLeftWorldPosition(this);
        }

        public IntVector2 ToCenteredWorldPosition()
        {
            return TilePositionComponent.TransformTilePositionToWorldCenteredPosition(this);
        }

        public override int GetHashCode()
        {
            return (x << 16) + y;
        }

        public override string ToString()
        {
            return $"{x},{y}";
        }
    }
}

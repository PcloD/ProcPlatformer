using GamePlatformer.Model.GameComponents;

namespace GamePlatformer.Model.Utils
{
    public static class TileUtils
    {
        static public bool IsSolid(int worldPositionX, int worldPositionY, GameContext gameContext)
        {
            return IsSolid(new IntVector2(worldPositionX, worldPositionY), gameContext);
        }

        static public bool IsSolid(IntVector2 worldPosition, GameContext gameContext)
        {
            var tilePosition = TilePositionComponent.TransformWorldPositionToTilePosition(worldPosition);

            return IsSolid(tilePosition, gameContext);
        }

        static public bool IsSolid(TilePosition tilePosition, GameContext gameContext)
        {
            return gameContext.GetEntitiesWithTilePosition(tilePosition).Count > 0;
        }
    }
}

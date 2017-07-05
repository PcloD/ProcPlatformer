using GamePlatformer.Model.GameComponents;

namespace GamePlatformer.Model.Utils
{
    public static class AvatarUtils
    {
        static public bool IsOnFloor(GameEntity avatarEntity, GameContext gameContext)
        {
            if (avatarEntity.position.y % TilePositionComponent.TileSize == TilePositionComponent.TileSize - 1)
            {
                var playerTilePosition = TilePositionComponent.TransformWorldPositionToTilePosition(new IntVector2(avatarEntity.position.x, avatarEntity.position.y));
                var tileBelowPlayer = playerTilePosition.BelowTilePosition();
                return gameContext.GetEntitiesWithTilePosition(tileBelowPlayer).Count > 0;
            }

            return false;
        }
    }
}

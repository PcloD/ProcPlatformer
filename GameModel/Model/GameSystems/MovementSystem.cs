using Entitas;
using GamePlatformer.Model.GameComponents;
using GamePlatformer.Model.Utils;

namespace GamePlatformer.Model.GameSystems
{
    public class MovementSystem : IInitializeSystem, IExecuteSystem
    {
        private IGroup<GameEntity> allMovablesGroup;
        private GameContext gameContext;

        public MovementSystem(GameContext gameContext)
        {
            this.gameContext = gameContext;

        }

        public void Initialize()
        {
            allMovablesGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Rigidbody, GameMatcher.Position));
        }

        public void Execute()
        {
            foreach (var entity in allMovablesGroup.GetEntities())
            {
                if (entity.rigidbody.speedX != 0 || entity.rigidbody.speedY != 0)
                {
                    var newX = entity.position.x + entity.rigidbody.speedX;
                    var newY = entity.position.y + entity.rigidbody.speedY;

                    var newTilePosition = TilePositionComponent.TransformWorldPositionToTilePosition(new IntVector2(newX, newY));

                    if (TileUtils.IsSolid(newX, newY, gameContext))
                    {
                        if (entity.rigidbody.speedY > 0)
                        {
                            entity.rigidbody.speedY = 0;
                            newY = newTilePosition.ToTopLeftWorldPosition().y - 1;
                        }
                    }

                    entity.ReplacePosition(newX, newY);
                }

                if (entity.rigidbody.useGravity)
                {
                    if (!AvatarUtils.IsOnFloor(entity, gameContext))
                    {
                        entity.rigidbody.speedY++;
                        if (entity.rigidbody.speedY > 10)
                            entity.rigidbody.speedY = 10;
                    }
                    else
                    {
                        entity.rigidbody.speedY = 0;
                    }
                }
            }
        }
    }
}

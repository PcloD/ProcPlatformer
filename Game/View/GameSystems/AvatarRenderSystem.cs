using Entitas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.TextureAtlases;
using MonoGame.Extended.Sprites;
using GamePlatformer.Model.GameComponents;
using System;
using GamePlatformer.View.Utils;

namespace GamePlatformer.View.GameSystems
{
    public class AvatarRenderSystem : IInitializeSystem, IExecuteSystem
    {
        private IGroup<GameEntity> allAvatarsGroup;
        private GameContext gameContext;
        private SpriteBatch spriteBatch;
        private TextureAtlas atlas;

        public AvatarRenderSystem(GameContext gameContext, SpriteBatch spriteBatch, TextureAtlas atlas)
        {
            this.gameContext = gameContext;
            this.spriteBatch = spriteBatch;
            this.atlas = atlas;
        }

        public void Initialize()
        {
            allAvatarsGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Avatar, GameMatcher.Position, GameMatcher.Size));
        }

        public void Execute()
        {
            foreach (var entity in allAvatarsGroup.GetEntities())
            {
                spriteBatch.Draw(GetSprite(entity.avatar), GetDrawRectangle(entity.position, entity.size), Color.White);
            }
        }

        private TextureRegion2D GetSprite(AvatarComponent avatar)
        {
            return atlas[avatar.id];
        }

        private Rectangle GetDrawRectangle(PositionComponent position, SizeComponent size)
        {
            return new Rectangle(new Point(position.x - size.x / 2, position.y - size.y), new Point(size.x, size.y));
        }
    }
}

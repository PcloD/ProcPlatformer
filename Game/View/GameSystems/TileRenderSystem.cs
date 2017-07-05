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
    public class TileRenderSystem : IInitializeSystem, IExecuteSystem
    {
        private IGroup<GameEntity> allTilesGroup;
        private GameContext gameContext;
        private SpriteBatch spriteBatch;
        private TextureAtlas atlas;

        public TileRenderSystem(GameContext gameContext, SpriteBatch spriteBatch, TextureAtlas atlas)
        {
            this.gameContext = gameContext;
            this.spriteBatch = spriteBatch;
            this.atlas = atlas;
            
        }

        public void Initialize()
        {
            allTilesGroup = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.TilePosition, GameMatcher.Tile));
        }

        public void Execute()
        {
            foreach(var entity in allTilesGroup.GetEntities())
            {
                spriteBatch.Draw(GetSprite(entity.tile), GetDrawRectangle(entity.tilePosition), Color.White);
            }
        }

        private TextureRegion2D GetSprite(TileComponent tile)
        {
            return atlas[tile.definition.id];
        }

        private Rectangle GetDrawRectangle(TilePositionComponent tilePosition)
        {
            return new Rectangle(tilePosition.TopLeftWorldPosition.ToPoint(), new Point(TilePositionComponent.TileSize, TilePositionComponent.TileSize));
        }
    }
}

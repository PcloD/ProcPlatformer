using Entitas;
using Microsoft.Xna.Framework.Graphics;
using GamePlatformer.View.GameSystems;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.TextureAtlases;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;
using GamePlatformer.View.Utils;
using Microsoft.Xna.Framework;

namespace GamePlatformer.View
{
    public class GameViewSystems
    {
        private Systems systems;
        private SpriteBatch spriteBatch;
        private TextureAtlas tilesAndItemsAtlas;
        private TextureAtlas entitiesAtlas;
        private Camera2D camera;

        private GameContext gameContext;
        private MapContext mapContext;

        public GameViewSystems(GameContext gameContext, MapContext mapContext, GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            this.gameContext = gameContext;
            this.mapContext = mapContext;

            InitView(graphicsDevice, contentManager);

            InitSystems();
        }

        private void InitView(GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            camera = new Camera2D(graphicsDevice);

            spriteBatch = new SpriteBatch(graphicsDevice);

            tilesAndItemsAtlas = contentManager.Load<TextureAtlas>("Spritesheets/tilesanditems-atlas");
            entitiesAtlas = contentManager.Load<TextureAtlas>("Spritesheets/entities-atlas");
        }

        private void InitSystems()
        {
            systems = new Systems()
                .Add(new TileRenderSystem(gameContext, spriteBatch, tilesAndItemsAtlas))
                .Add(new AvatarRenderSystem(gameContext, spriteBatch, entitiesAtlas));

            systems.Initialize();

            camera.LookAt(new Vector2(gameContext.playerAvatarEntity.position.x, gameContext.playerAvatarEntity.position.y));
        }

        public void ExecuteSystems()
        {
            camera.LookAt(new Vector2(gameContext.playerAvatarEntity.position.x, gameContext.playerAvatarEntity.position.y));

            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());
            {
                systems.Execute();
                systems.Cleanup();
            }
            spriteBatch.End();
        }

        public void TearDownSystems()
        {
            systems.TearDown();
        }
    }
}

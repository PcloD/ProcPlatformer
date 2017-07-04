using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.TextureAtlases;

namespace GamePlatformer.Utils
{
    public class Map
    {
        private SpriteBatch batch;
        private TextureAtlas tilesAndItemsAtlas;

        public Map(GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            batch = new SpriteBatch(graphicsDevice);

            tilesAndItemsAtlas = contentManager.Load<TextureAtlas>("Spritesheets/tilesanditems-atlas");
        }
        
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {
            var tile = tilesAndItemsAtlas["grassCenter"];
            var tileSize = tile.Width;

            batch.Begin();
            {
                for (int x = 0; x < 10; x++)
                    for (int y = 0; y < 15; y++)
                        batch.Draw(tile, new Vector2(x * tileSize, y * tileSize), Color.White);
            }
            batch.End();
        }
    }
}

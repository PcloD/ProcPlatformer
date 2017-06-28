using GamePlatformer.Screens;
using GamePlatformer.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;

namespace GamePlatformer
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch batch;
        private BitmapFont font;

        private IPlatform platform;

        private GuiManager guiManager;

        public MainGame(IPlatform platform)
        {
            this.platform = platform;

            InitGraphics();

            InitContent();
        }

        private void InitContent()
        {
            Content.RootDirectory = "Content";
        }

        private void InitGraphics()
        {
            graphics = new GraphicsDeviceManager(this);

            if (platform.PlatformType == PlatformType.Desktop)
            {
                graphics.PreferredBackBufferWidth = GuiManager.DEFAULT_GUI_HEIGHT * GuiManager.DEFAULT_ASPECT_RATIO_BASE_100 / 100;
                graphics.PreferredBackBufferHeight = GuiManager.DEFAULT_GUI_HEIGHT;

                graphics.IsFullScreen = false;
                //Window.AllowUserResizing = true;
            }
            else
            {
                graphics.IsFullScreen = true;
                this.IsMouseVisible = false;
            }
        }

        private void InitGUI()
        {
            guiManager = new GuiManager(Content, Window, GraphicsDevice, platform, "Content/adventure-gui-skin.json");

            guiManager.RegisterScreen<TitleScreen>();

            guiManager.ShowScreen<TitleScreen>();
        }

        protected override void LoadContent()
        {
            batch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<BitmapFont>("small-font");

            InitGUI();
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsExitCombinationExecuted())
                Exit();

            guiManager.Update(gameTime);

            base.Update(gameTime);
        }

        private bool IsExitCombinationExecuted()
        {
            return platform.PlatformType == PlatformType.Android &&
                    (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                    Keyboard.GetState().IsKeyDown(Keys.Escape));

        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            var pointerState = Pointer.GetState();

            if (pointerState.Button == ButtonState.Pressed)
                GraphicsDevice.Clear(Color.ForestGreen);
            else
                GraphicsDevice.Clear(Color.CornflowerBlue);

            guiManager.Draw(gameTime);

            //guiRenderer.Begin();
            //{
            //    guiRenderer.DrawText(font, "Hello World: " + guiCamera.ScreenToWorld(pointerState.Position.ToVector2()), guiCamera.WorldToScreen(0, 0), Color.White);
            //}
            //guiRenderer.End();
        }
    }
}

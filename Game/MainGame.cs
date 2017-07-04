using GamePlatformer.Screens;
using GamePlatformer.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;
using Libraries.GUI;
using Libraries.Input;
using System;
using GamePlatformer.Model;

namespace GamePlatformer
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch batch;
        private BitmapFont font;

        private IPlatform platform;

        private GuiManager guiManager;

        private GraphicsMetrics lastMetrics;

        private Map map;

        private GameModel gameModel;

        public MainGame(IPlatform platform)
        {
            this.platform = platform;

            InitTime();

            InitGraphics();

            InitContent();

            InitGameModel();
        }

        private void InitGameModel()
        {
            gameModel = new GameModel();
        }

        private void InitTime()
        {
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 60.0f); //Update runs at 60 fps
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

            graphics.SynchronizeWithVerticalRetrace = true;
        }

        private void InitGUI()
        {
            guiManager = new GuiManager(Content, Window, GraphicsDevice, "Content/adventure-gui-skin.json");

            guiManager.RegisterScreen(new TitleScreen(() => lastMetrics ));

            guiManager.ShowScreen<TitleScreen>();
        }

        protected override void LoadContent()
        {
            batch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<BitmapFont>("small-font");

            InitGUI();

            InitMap();
        }

        private void InitMap()
        {
            map = new Map(GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsExitCombinationExecuted())
                Exit();

            guiManager.Update(gameTime);

            map.Update(gameTime);

            gameModel.ExecuteModelSystems();

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

            var pointerState = InputPointer.GetState();

            if (pointerState.Button == ButtonState.Pressed)
                GraphicsDevice.Clear(Color.ForestGreen);
            else
                GraphicsDevice.Clear(Color.CornflowerBlue);

            map.Draw(gameTime);

            gameModel.ExecuteRenderSystems();

            guiManager.Draw(gameTime);

            lastMetrics = GraphicsDevice.Metrics;


            //guiRenderer.Begin();
            //{
            //    guiRenderer.DrawText(font, "Hello World: " + guiCamera.ScreenToWorld(pointerState.Position.ToVector2()), guiCamera.WorldToScreen(0, 0), Color.White);
            //}
            //guiRenderer.End();
        }
    }
}

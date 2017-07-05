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
using GamePlatformer.View;

namespace GamePlatformer
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager graphics;

        private IPlatform platform;

        private GuiManager guiManager;

        private GraphicsMetrics lastMetrics;

        private GameModelSystems gameModel;

        private GameViewSystems gameView;

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
            gameModel = new GameModelSystems();
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

        protected override void LoadContent()
        {
            InitGUI();

            InitGameView();
        }

        private void InitGUI()
        {
            guiManager = new GuiManager(Content, Window, GraphicsDevice, "Content/adventure-gui-skin.json");

            guiManager.RegisterScreen(new TitleScreen(() => lastMetrics));
            guiManager.RegisterScreen(new PlayScreen(() => lastMetrics));

            guiManager.ShowScreen<PlayScreen>();
        }

        private void InitGameView()
        {
            gameView = new GameViewSystems(Contexts.sharedInstance.game, Contexts.sharedInstance.map, graphics.GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsExitCombinationExecuted())
                Exit();

            guiManager.Update(gameTime);

            DispatchPlayerAvatarInput();

            gameModel.ExecuteSystems();

            base.Update(gameTime);
        }

        private void DispatchPlayerAvatarInput()
        {
            var direction = 0;
            var jump = false;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                direction--;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                direction++;

            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Space))
                jump = true;

            Contexts.sharedInstance.input.CreateEntity().AddPlayerAvatarInput(direction, jump);
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

            GraphicsDevice.Clear(Color.CornflowerBlue);

            gameView.ExecuteSystems();

            guiManager.Draw(gameTime);

            lastMetrics = GraphicsDevice.Metrics;
        }
    }
}

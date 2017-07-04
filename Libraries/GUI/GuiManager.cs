using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Gui;
using MonoGame.Extended.ViewportAdapters;
using System.Collections.Generic;

namespace Libraries.GUI
{
    public class GuiManager
    {
        public const int DEFAULT_GUI_HEIGHT = 800;
        public const int DEFAULT_ASPECT_RATIO_BASE_100 = 60; //0.6

        private readonly ViewportAdapter viewportAdapter;
        private readonly Camera2D guiCamera;
        private readonly GuiSystem guiSystem;
        private readonly IGuiRenderer guiRenderer;

        private readonly ContentManager contentManager;
        private readonly GraphicsDevice graphicsDevice;
        private readonly GameWindow gameWindow;

        private readonly List<BaseScreen> screens = new List<BaseScreen>();

        private BaseScreen activeScreen;

        public GuiSkin DefaultSkin
        {
            get; private set;
        }

        public BaseScreen ActiveScreen
        {
            get { return activeScreen; }
        }

        public Vector2 ScreenSize
        {
            get { return guiCamera.BoundingRectangle.Size; }
        }

        public GuiManager()
        {
        }

        public GuiManager(ContentManager contentManager, GameWindow gameWindow, GraphicsDevice graphicsDevice, string defaultSkinFileName)
        {
            this.contentManager = contentManager;
            this.gameWindow = gameWindow;
            this.graphicsDevice = graphicsDevice;
            
            int width = (int)(DEFAULT_GUI_HEIGHT * graphicsDevice.Viewport.AspectRatio);
            int height = DEFAULT_GUI_HEIGHT;

            viewportAdapter = new BoxingViewportAdapter(gameWindow, graphicsDevice, width, height, width, 0); //Fixed height, any width
            guiCamera = new Camera2D(viewportAdapter);
            guiRenderer = new GuiSpriteBatchRenderer(graphicsDevice, guiCamera.GetViewMatrix);
            guiSystem = new GuiSystem(viewportAdapter, guiRenderer);

            DefaultSkin = GuiSkin.FromFile(contentManager, defaultSkinFileName);

            DefaultSkin.Cursor = null;
        }

        public void RegisterScreen<T>() where T : BaseScreen, new()
        {
            RegisterScreen(new T());
        }

        public void RegisterScreen(BaseScreen screen)
        {
            screen.Build(this, contentManager);
            screens.Add(screen);
        }

        public void ShowScreen<T>() where T : BaseScreen
        {
            var screen = screens.Find(x => x is T);

            if (screen == null)
                throw new Exception("Unknown screen " + typeof(T).Name);

            if (screen != activeScreen)
            {
                if (activeScreen != null)
                    activeScreen.Hide();

                activeScreen = screen;
                guiSystem.Screen = screen.Gui;
                activeScreen.Show();
            }
        }

        public void Update(GameTime gameTime)
        {
            activeScreen.Update(gameTime);
            guiSystem.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            guiSystem.Draw(gameTime);
        }

        public Vector2 ScreenToWorld(float x, float y)
        {
            return guiCamera.ScreenToWorld(x, y);
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return guiCamera.ScreenToWorld(screenPosition);
        }

        public Vector2 WorldToScreen(float x, float y)
        {
            return guiCamera.WorldToScreen(x, y);
        }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return guiCamera.WorldToScreen(worldPosition);
        }
    }
}

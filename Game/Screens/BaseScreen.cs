using MonoGame.Extended.Gui;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;

namespace GamePlatformer.Screens
{
    public abstract class BaseScreen
    {
        internal GuiScreen Gui
        {
            get;
            private set;
        }

        internal GuiManager GuiManager
        {
            get;
            private set;
        }

        protected ContentManager ContentManager
        {
            get;
            private set;
        }

        public BaseScreen()
        {
        }

        public void Build(GuiManager guiManager, ContentManager contentManager)
        {
            this.GuiManager = guiManager;
            this.ContentManager = contentManager;

            Gui = BuildGui();

            OnBindToGui();
        }

        protected abstract GuiScreen BuildGui();

        protected virtual void OnBindToGui()
        {

        }

        internal void Show()
        {
            OnShow();
        }

        protected virtual void OnShow()
        {
            
        }

        internal void Hide()
        {
            OnHide();
        }

        protected virtual void OnHide()
        {
            
        }

        internal void Update(GameTime gameTime)
        {
            OnUpdate(gameTime);
        }

        protected virtual void OnUpdate(GameTime gameTime)
        {
            
        }
    }
}

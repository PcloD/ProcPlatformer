using GamePlatformer.Utils;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Gui;
using MonoGame.Extended.Gui.Controls;

namespace GamePlatformer.Screens
{
    class TitleScreen : FileScreen
    {
        private GuiLabel mainLabel;

        public TitleScreen() : base("Content/title-screen.json")
        {

        }

        protected override void OnBindToGui()
        {
            Gui.FindControl<GuiButton>("PlayButton").Clicked += (a, b) => DoSomething();
            mainLabel = Gui.FindControl<GuiLabel>("MainLabel");
        }

        private void DoSomething()
        {
            mainLabel.Text = "Bla bla bla..";
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            var pointerState = Pointer.GetState();

            mainLabel.Text = "Input position: " + GuiManager.ScreenToWorld(pointerState.Position.ToVector2());
        }
    }
}

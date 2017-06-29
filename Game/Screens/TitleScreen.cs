using GamePlatformer.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Gui.Controls;
using System;

namespace GamePlatformer.Screens
{
    class TitleScreen : FileScreen
    {
        private GuiLabel mainLabel;
        private Func<GraphicsMetrics> graphicsMetricsProvider;

        public TitleScreen(Func<GraphicsMetrics> graphicsMetricsProvider) : base("Content/title-screen.json")
        {
            this.graphicsMetricsProvider = graphicsMetricsProvider;
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

            var metrics = graphicsMetricsProvider();

            mainLabel.Text = "Input position: " + GuiManager.ScreenToWorld(pointerState.Position.ToVector2()) + "\nStats: " +
                $"Draws: {metrics.DrawCount}\nTextures: {metrics.TextureCount}\nPrimitives: {metrics.PrimitiveCount}";
        }
    }
}

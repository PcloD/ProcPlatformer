using MonoGame.Extended.Gui;

namespace GamePlatformer.Screens
{
    public class FileScreen : BaseScreen
    {
        private readonly string fileName;

        public FileScreen(string fileName)
        {
            this.fileName = fileName;
        }

        protected override GuiScreen BuildGui()
        {
            return GuiScreen.FromFile(ContentManager, fileName);
        }
    }
}

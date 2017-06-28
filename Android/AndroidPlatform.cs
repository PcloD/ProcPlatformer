using GamePlatformer.Utils;
using Microsoft.Xna.Framework;

namespace GamePlatformer.Android
{
    internal class AndroidPlatform : IPlatform
    {
        public PlatformType PlatformType => PlatformType.Android;

        private AndroidGameActivity activity;

        public AndroidPlatform(AndroidGameActivity mainActivity)
        {
            this.activity = mainActivity;
        }
    }
}
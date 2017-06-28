using GamePlatformer.Utils;
using System;

namespace GamePlatformer.Desktop
{
    internal class DesktopPlatform : IPlatform
    {
        public PlatformType PlatformType => PlatformType.Desktop;
    }
}
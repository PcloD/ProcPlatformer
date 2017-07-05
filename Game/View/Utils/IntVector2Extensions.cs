using GamePlatformer.Model.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatformer.View.Utils
{
    public static class IntVector2Extensions
    {
        public static Vector2 ToVector2(this IntVector2 intVector2)
        {
            return new Vector2(intVector2.x, intVector2.y);
        }

        public static Point ToPoint(this IntVector2 intVector2)
        {
            return new Point(intVector2.x, intVector2.y);
        }
    }
}

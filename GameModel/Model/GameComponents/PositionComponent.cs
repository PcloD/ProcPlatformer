﻿using Entitas;

namespace GamePlatformer.Model.GameComponents
{
    [Game]
    public sealed class PositionComponent : IComponent
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return $"Position({x},{y})";
        }
    }
}

using System;
using Entitas;

namespace GamePlatformer.Model.GameComponents
{
    [Game]
    public class RigidbodyComponent : IComponent
    {
        public int speedX;
        public int speedY;
        public bool useGravity;

        public void Stop()
        {
            speedX = speedY = 0;
        }
    }
}

using Entitas;

namespace GamePlatformer.Model.GameComponents
{
    [Game]
    public sealed class PositionComponent : IComponent
    {
        public float x;
        public float y;

        public override string ToString()
        {
            return "Position(" + x + ", " + y + ")";
        }
    }
}

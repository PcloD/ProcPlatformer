using Entitas;

namespace GamePlatformer.Model.GameComponents
{
    [Game]
    public sealed class SizeComponent : IComponent
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return $"Size({x},{y})";
        }
    }
}

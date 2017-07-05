using Entitas;

namespace GamePlatformer.Model.GameComponents
{
    [Input]
    public class PlayerAvatarInputComponent : IComponent
    {
        public int horizontalDirection;
        public bool jump;
    }
}

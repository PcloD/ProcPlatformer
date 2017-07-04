using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Libraries.Input
{
    public struct PointerState
    {
        public PointerState(Point point, ButtonState pressed) : this()
        {
            this.Position = point;
            this.Button = pressed;
        }

        public int X { get; }
        public int Y { get; }
        public Point Position { get; }
        public ButtonState Button { get; }


    }

    public class InputPointer
    {
        static public PointerState GetState()
        {
            var touchState = TouchPanel.GetState();
            var mouseState = Mouse.GetState();

            if (touchState.IsConnected && touchState.Count > 0)
            {
                var touchLocation = touchState[0];

                return new PointerState(touchLocation.Position.ToPoint(), ButtonState.Pressed);
            }

            return new PointerState(mouseState.Position, mouseState.LeftButton);
        }
    }
}

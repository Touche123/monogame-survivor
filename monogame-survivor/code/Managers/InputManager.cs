using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace monogame_survivor
{
    public static class InputManager
    {
        private static MouseState lastMouseState;
        private static KeyboardState lastKeyboardState;
        private static Vector2 direction;
        public static Vector2 Direction => direction;
        public static Point MousePosition => Mouse.GetState().Position;
        public static bool MouseClicked { get; private set; }
        public static bool MouseRightClicked { get; private set; }
        public static bool MouseLeftDown { get; private set; }
        public static bool SpacePressed { get; private set; }

        public static void Update()
        {
            var KeyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            direction = Vector2.Zero;
            if (KeyboardState.IsKeyDown(Keys.W)) direction.Y--;
            if (KeyboardState.IsKeyDown(Keys.S)) direction.Y++;
            if (KeyboardState.IsKeyDown(Keys.A)) direction.X--;
            if (KeyboardState.IsKeyDown(Keys.D)) direction.X++;

            MouseLeftDown = mouseState.LeftButton == ButtonState.Pressed;
            MouseClicked = MouseLeftDown && (lastMouseState.LeftButton == ButtonState.Released);
            MouseRightClicked = mouseState.RightButton == ButtonState.Pressed
                                && (lastMouseState.RightButton == ButtonState.Released);

            SpacePressed = lastKeyboardState.IsKeyUp(Keys.Space) && KeyboardState.IsKeyDown(Keys.Space);

            lastMouseState = mouseState;
            lastKeyboardState = KeyboardState;
        }
    }
}

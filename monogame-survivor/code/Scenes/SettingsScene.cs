using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_survivor
{
    internal class SettingsScene : SceneComponent
    {
        internal override void Draw(SpriteBatch spriteBatch)
        {
        }

        internal override void LoadContent(ContentManager Content)
        {
        }

        internal override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Escape))
                Data.CurrentState = Data.Scenes.Menu;
        }
    }
}
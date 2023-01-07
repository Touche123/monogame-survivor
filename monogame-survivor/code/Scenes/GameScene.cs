using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_survivor
{
    internal class GameScene : SceneComponent
    {
        private Player player = new Player();
        internal override void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }

        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Escape))
                Data.CurrentState = Data.Scenes.Menu;
        }
    }
}
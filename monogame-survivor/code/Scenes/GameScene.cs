using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_survivor
{
    internal class GameScene : SceneComponent
    {
        private Player player = new Player();
        private readonly Map map = new();
        internal override void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }

        internal override void LoadContent(ContentManager Content)
        {
            map.LoadContent(Content);
            player.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            map.Update(gameTime);
            player.Update(gameTime);
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Escape))
                Data.CurrentState = Data.Scenes.Menu;
        }
    }
}
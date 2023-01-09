using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_survivor
{
    internal abstract class GameComponent
    {
        public int ZOrder = 0;
        internal abstract void Draw(SpriteBatch spriteBatch);
        internal abstract void LoadContent(ContentManager content);
        internal abstract void Update(GameTime gameTime);
    }
}
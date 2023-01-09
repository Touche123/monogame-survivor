using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_survivor
{
    internal class Tile : SceneComponent
    {
        private readonly Texture2D texture;
        private readonly Vector2 position;
        private bool mouseSelected;

        public Tile(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (mouseSelected) color = Color.Red;
            spriteBatch.Draw(texture, position, color);
        }

        internal override void LoadContent(ContentManager Content)
        {
        }

        internal override void Update(GameTime gameTime)
        {
        }

        public void MouseSelect()
        {
            mouseSelected = true;
        }

        public void MouseDeselect()
        {
            mouseSelected = false;
        }
    }
}
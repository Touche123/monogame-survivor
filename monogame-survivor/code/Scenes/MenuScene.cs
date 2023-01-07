using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_survivor
{
    internal class MenuScene : SceneComponent
    {
        private Texture2D PlayTexture;
        private Texture2D SettingsTexture;
        private Texture2D ExitTexture;
        private Rectangle PlayRectangle;
        private Rectangle SettingsRectangle;
        private Rectangle ExitRectangle;
        private MouseState ms, oldMS;
        private Rectangle mouseRectangle;
        internal override void LoadContent(ContentManager Content)
        {
            PlayTexture = Content.Load<Texture2D>("Play");
            SettingsTexture = Content.Load<Texture2D>("Settings");
            ExitTexture = Content.Load<Texture2D>("Exit");
            int MenuStartX = Game1.graphics.GraphicsDevice.Viewport.Bounds.Width / 2 - 100;
            int MenuStartY = Game1.graphics.GraphicsDevice.Viewport.Bounds.Height / 2 - 120;
            PlayRectangle = new Rectangle(MenuStartX, MenuStartY, PlayTexture.Width, PlayTexture.Height);
            SettingsRectangle = new Rectangle(MenuStartX, MenuStartY + 120, SettingsTexture.Width, SettingsTexture.Height);
            ExitRectangle = new Rectangle(MenuStartX, MenuStartY + 240, ExitTexture.Width, ExitTexture.Height);
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayTexture, PlayRectangle, Color.White);
            spriteBatch.Draw(SettingsTexture, SettingsRectangle, Color.White);
            spriteBatch.Draw(ExitTexture, ExitRectangle, Color.White);

            if (mouseRectangle.Intersects(PlayRectangle))
                spriteBatch.Draw(PlayTexture, PlayRectangle, Color.Gray);
            if (mouseRectangle.Intersects(SettingsRectangle))
                spriteBatch.Draw(SettingsTexture, SettingsRectangle, Color.Gray);
            if (mouseRectangle.Intersects(ExitRectangle))
                spriteBatch.Draw(ExitTexture, ExitRectangle, Color.Gray);
        }


        internal override void Update(GameTime gameTime)
        {
            oldMS = ms;
            ms = Mouse.GetState();
            mouseRectangle = new Rectangle(ms.X, ms.Y, 1, 1);

            if (ms.LeftButton == ButtonState.Pressed && mouseRectangle.Intersects(PlayRectangle))
                Data.CurrentState = Data.Scenes.Game;
            if (ms.LeftButton == ButtonState.Pressed && mouseRectangle.Intersects(SettingsRectangle))
                Data.CurrentState = Data.Scenes.Settings;
            if (ms.LeftButton == ButtonState.Pressed && mouseRectangle.Intersects(ExitRectangle))
                Data.GameRef.Exit();
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_survivor
{
    public class GameState : State
    {
        Texture2D ballTexture;
        Vector2 ballPosition;
        float ballSpeed;

        private Player player;
        public GameState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            player = new Player();
            ballTexture = Globals.Content.Load<Texture2D>("ball");
            ballPosition = new Vector2(_graphicsDevice.PreferredBackBufferWidth / 2,
                                        _graphicsDevice.PreferredBackBufferHeight / 2);
            ballSpeed = 100f;

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(
                player.Graphics,
                player.Position,
                null,
                Color.White,
                0f,
                new Vector2(player.Graphics.Width / 2, player.Graphics.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.Exit();

            player.Update(gameTime);
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.A))
            {
                ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.D))
            {
                ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (ballPosition.X > _graphicsDevice.PreferredBackBufferWidth - ballTexture.Width / 2)
            {
                ballPosition.X = _graphicsDevice.PreferredBackBufferWidth - ballTexture.Width / 2;
            }
            else if (ballPosition.X < ballTexture.Width / 2)
            {
                ballPosition.X = ballTexture.Width / 2;
            }

            if (ballPosition.Y > _graphicsDevice.PreferredBackBufferHeight - ballTexture.Height / 2)
            {
                ballPosition.Y = _graphicsDevice.PreferredBackBufferHeight - ballTexture.Height / 2;
            }
            else if (ballPosition.Y < ballTexture.Height / 2)
            {
                ballPosition.Y = ballTexture.Height / 2;
            }
        }
    }

}
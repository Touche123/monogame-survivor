using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_survivor
{
    public class Player
    {
        public Vector2 Position;
        private Vector2 Direction;
        private float Speed = 100;
        private int Health;
        private List<IWeapon> weapons;
        private IWeapon activeWeapon;
        public Texture2D Graphics;
        public Player()
        {
            weapons = new List<IWeapon>();
            weapons.Add(new SimpleGun());
            activeWeapon = weapons[0];
            Graphics = Globals.Content.Load<Texture2D>("ball");
            Position = new Vector2(0, 0);
        }

        private void Fire()
        {
            activeWeapon.Fire();
        }

        public void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            Direction.X = 0;
            Direction.Y = 0;

            if (kstate.IsKeyDown(Keys.W))
            {
                Direction.Y = -1;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                Direction.Y = 1;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                Direction.X = -1;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                Direction.X = 1;
            }
            if (kstate.IsKeyDown(Keys.Space))
            {
                Fire();
            }

            Position.X += Direction.X * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.Y += Direction.Y * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            activeWeapon.Update(gameTime);
        }
    }
}
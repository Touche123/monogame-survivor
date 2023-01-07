using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_survivor
{
    public interface IProjectile
    {
        void Update(GameTime gameTime);
        bool GetShouldDestroy();
    }
    public abstract class ProjectileBase : IProjectile
    {
        public Vector2 Position;
        public Vector2 Direction;
        public float Speed;
        public Texture2D Texture;
        private int MaxLifetime = 10;
        private float LifeTime = 0f;
        private bool ShouldDestroy = false;
        public ProjectileBase(Vector2 startPos, Vector2 direction)
        {

        }
        public virtual void Update(GameTime gameTime)
        {
            LifeTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (LifeTime >= MaxLifetime)
                ShouldDestroy = true;

            Position.X += Direction.X * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position.Y += Direction.Y * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public abstract void Destroy();
        public bool GetShouldDestroy()
        {
            if (ShouldDestroy) return true;
            else return false;
        }
    }
}
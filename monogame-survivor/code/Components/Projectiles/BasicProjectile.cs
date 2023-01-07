using Microsoft.Xna.Framework;

namespace monogame_survivor
{
    public class BasicProjectile : ProjectileBase
    {
        public BasicProjectile(Vector2 startPos, Vector2 direction) : base(startPos, direction)
        {
        }
        public override void Destroy()
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
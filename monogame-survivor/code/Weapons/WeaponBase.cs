using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace monogame_survivor
{
    public interface IWeapon
    {
        public void Update(GameTime gameTime);
        public void Fire();
    }
    public abstract class WeaponBase : IWeapon
    {
        public List<IProjectile> projectiles;
        public WeaponBase()
        {
            projectiles = new List<IProjectile>();
        }
        public abstract void Fire();
        public void Update(GameTime gameTime)
        {
            Debug.WriteLine(projectiles.Count);

            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update(gameTime);
                if (projectiles[i].GetShouldDestroy())
                    projectiles.RemoveAt(i);
            }
        }
    }

    public class SimpleGun : WeaponBase
    {
        public override void Fire()
        {
            projectiles.Add(new BasicProjectile(new Vector2(0, 0), new Vector2(1, 0)));
        }
    }
}
using System;
using UnityEngine;

namespace Asteroids.Model
{
    public abstract class Bullet
    {
        public readonly Vector2 Size;
        public readonly float Lifetime;
        public readonly float Speed;

        protected Bullet(Vector2 size, float lifetime, float speed)
        {
            Size = size;
            Lifetime = lifetime;
            Speed = speed;
        }
    }

    public class LaserGunBullet : Bullet
    {
        public LaserGunBullet() : base(new Vector2(1, 100), 0.5F, 0F) { }
    }

    public class DefaultBullet : Bullet
    {
        public DefaultBullet() : base(new Vector2(1, 1), 10F, 0.6F) { }
    }
}

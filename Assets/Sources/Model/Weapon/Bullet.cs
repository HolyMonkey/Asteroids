using System;
using UnityEngine;

namespace Asteroids.Model
{
    public abstract class Bullet
    {
        public readonly float Lifetime;
        public readonly float Speed;

        protected Bullet(float lifetime, float speed)
        {
            Lifetime = lifetime;
            Speed = speed;
        }
    }

    public class LaserGunBullet : Bullet
    {
        public LaserGunBullet() : base(0.5F, 0F) { }
    }

    public class DefaultBullet : Bullet
    {
        public DefaultBullet() : base(10F, 0.6F) { }
    }
}

using System;
using UnityEngine;

namespace Asteroids.Model
{
    public abstract class Bullet
    {
        public readonly Vector2 Direction;
        public readonly Vector2 Size;

        protected Bullet(Vector2 direction)
        {
            Direction = direction;
        }
    }

    public class LaserGunBullet : Bullet
    {
        public LaserGunBullet(Vector2 direction) : base(direction)
        {
        }
    }

    public class DefaultBullet : Bullet
    {
        public readonly float Speed;

        public DefaultBullet(Vector2 direction) : base(direction)
        {
        }
    }
}

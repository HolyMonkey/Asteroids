using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class BaseGun : IGun
    {
        public event Action<Bullet> Shot;

        public virtual bool CanShoot() => true;

        public void Shoot(Vector2 direction)
        {
            if (CanShoot() == false)
                throw new InvalidOperationException();

            Bullet bullet = GetBullet(direction);
            Shot?.Invoke(bullet);
        }

        protected virtual Bullet GetBullet(Vector2 direction) => new DefaultBullet(direction);
    }
}

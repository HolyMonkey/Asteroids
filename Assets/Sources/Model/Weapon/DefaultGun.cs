using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class DefaultGun
    {
        public event Action<Bullet> Shot;

        public virtual bool CanShoot() => true;

        public void Shoot()
        {
            if (CanShoot() == false)
                throw new InvalidOperationException();

            Bullet bullet = GetBullet();
            Shot?.Invoke(bullet);
        }

        protected virtual Bullet GetBullet() => new DefaultBullet();
    }
}

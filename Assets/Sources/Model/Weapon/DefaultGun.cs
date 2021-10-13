using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class DefaultGun
    {
        protected readonly Ship Ship;

        public DefaultGun(Ship ship)
        {
            Ship = ship;
        }

        public virtual bool CanShoot() => true;

        public event Action<Bullet> Shot;


        public void Shoot()
        {
            if (CanShoot() == false)
                throw new InvalidOperationException();

            Bullet bullet = GetBullet();
            Shot?.Invoke(bullet);
        }

        protected virtual Bullet GetBullet() => new DefaultBullet(Ship.Position, Ship.Forward, Config.DefaultBulletSpeed);
    }
}

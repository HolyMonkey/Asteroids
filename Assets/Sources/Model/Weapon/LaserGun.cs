using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class LaserGun : BaseGun
    {
        private int _bullets;
        private int _bulletsPerShot;

        public LaserGun(int bullets, int bulletsPerShot = 1)
        {
            if (bulletsPerShot < 0)
                throw new ArgumentOutOfRangeException(nameof(bulletsPerShot));

            if (bullets <= 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            _bullets = bullets;
            _bulletsPerShot = bulletsPerShot;
        }

        public override bool CanShoot() => _bullets >= _bulletsPerShot;

        protected override Bullet GetBullet(Vector2 direction)
        {
            _bullets -= _bulletsPerShot;
            return new LaserGunBullet(direction);
        }
    }
}

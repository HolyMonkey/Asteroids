using System;

namespace Asteroids.Model
{
    public class DefaultGun
    {
        protected readonly Transformable _point;

        public DefaultGun(Transformable point)
        {
            _point = point;
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

        protected virtual Bullet GetBullet() => new DefaultBullet(_point.Position, _point.Forward, Config.DefaultBulletSpeed);
    }
}

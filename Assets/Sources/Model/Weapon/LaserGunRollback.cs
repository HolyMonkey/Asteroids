using UnityEngine;

namespace Asteroids.Model
{
    public class LaserGunRollback
    {
        public readonly float Cooldown;

        private readonly LaserGun _laser;

        public float AccumulatedTime { get; private set; }

        public LaserGunRollback(LaserGun laser, float cooldown)
        {
            _laser = laser;
            Cooldown = cooldown;
        }

        public void Tick(float deltaTime)
        {
            if (_laser.Bullets == _laser.MaxBullets)
                return;

            AccumulatedTime += deltaTime;

            if (AccumulatedTime >= Cooldown)
            {
                _laser.TryAddShot();
                AccumulatedTime = 0;
            }
        }
    }
}

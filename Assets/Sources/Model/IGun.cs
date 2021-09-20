using System;

namespace Asteroids.Model
{
    public interface IGun
    {
        public bool CanShoot();
        public void Shoot();

        public event Action Shot;
    }
}

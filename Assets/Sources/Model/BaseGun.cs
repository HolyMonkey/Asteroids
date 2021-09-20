using System;

namespace Asteroids.Model
{
    public class BaseGun : IGun
    {
        public event Action Shot;

        public virtual bool CanShoot() => true;

        public void Shoot()
        {
            if (CanShoot() == false)
                throw new InvalidOperationException();

            OnShooting();
            Shot?.Invoke();
        }

        protected virtual void OnShooting() { }
    }
}

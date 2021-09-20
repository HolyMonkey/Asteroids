using System;
using UnityEngine;

namespace Asteroids.Model
{
    public interface IGun
    {
        public bool CanShoot();
        public void Shoot(Vector2 direction);

        public event Action<Bullet> Shot;
    }
}

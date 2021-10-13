using UnityEngine;

namespace Asteroids.Model
{
    public class LaserGunBullet : Bullet
    {
        public LaserGunBullet(Vector2 position, Vector2 direction) : base(position, 0.5F, 0F) 
        {
            Rotate(Vector2.SignedAngle(Vector2.up, direction));
        }
    }
}

using UnityEngine;

namespace Asteroids.Model
{
    public class DefaultBullet : Bullet
    {
        private readonly Vector2 _direction;
        private readonly float _speed;

        public DefaultBullet(Vector2 position, Vector2 direction, float speed) : base(position, 10F, speed)
        {
            _direction = direction;
            _speed = speed;
        }

        public override void Update(float deltaTime)
        {
            Vector2 nextPosition = Position + _direction * _speed * deltaTime;

            MoveTo(nextPosition);

            base.Update(deltaTime);
        }
    }
}

using UnityEngine;

namespace Asteroids.Model
{
    public class Asteroid : Enemy
    {
        private readonly Vector2 _direction;
        private readonly float _speed;

        public Asteroid(Vector2 position, Vector2 direction, float speed) : base(position, 0)
        {
            _direction = direction;
            _speed = speed;
        }

        public override void Update(float deltaTime)
        {
            MoveTo(Position + _direction * _speed * deltaTime);
        }

        public PartOfAsteroid CreatePart()
        {
            return new PartOfAsteroid(Position, Random.insideUnitCircle.normalized, _speed / 2);
        }
    }

    public class PartOfAsteroid : Asteroid
    {
        public PartOfAsteroid(Vector2 position, Vector2 direction, float speed) : base(position, direction, speed) { }
    }
}

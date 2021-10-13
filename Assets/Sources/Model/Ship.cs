using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class Ship : Transformable
    {
        public Ship(Vector2 position, float rotation) : base(position, rotation) { }

        private readonly float _unitsPerSecond = 0.001f;
        private readonly float _maxSpeed = 0.0015f;
        private readonly float _secondsToStop = 1f;
        private readonly float _degreesPerSecond = 180;

        public Vector2 Acceleration { get; private set; }
        public Vector2 Forward => Quaternion.Euler(0, 0, Rotation) * Vector3.up;

        public void Accelerate(float deltaTime)
        {
            Acceleration += Forward * (_unitsPerSecond * deltaTime);
            Acceleration = Vector2.ClampMagnitude(Acceleration, _maxSpeed);

            Move(Acceleration);
        }

        public void Slowdown(float deltaTime)
        {
            Acceleration -= Acceleration * (deltaTime / _secondsToStop);

            Move(Acceleration);
        }

        private void Move(Vector2 delta)
        {
            var nextPosition = Position + delta;

            nextPosition.x = Mathf.Repeat(nextPosition.x, 1);
            nextPosition.y = Mathf.Repeat(nextPosition.y, 1);

            MoveTo(nextPosition);
        }

        public void Rotate(float direction, float deltaTime)
        {
            if (direction == 0)
                throw new InvalidOperationException(nameof(direction));

            direction = direction > 0 ? 1 : -1;

            Rotate(direction * deltaTime * _degreesPerSecond);
        }
    }
}

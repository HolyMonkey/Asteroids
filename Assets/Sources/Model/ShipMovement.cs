using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class ShipMovement
    {
        private readonly Ship _ship;
        private readonly float _degreesPerSecond = 180;

        public Vector2 Forward => Quaternion.Euler(0, 0, _ship.Rotation) * Vector3.up;

        public ShipMovement(Ship ship)
        {
            _ship = ship;
        }

        public void Move(Vector2 delta)
        {
            _ship.MoveLooped(delta);
        }

        public void Rotate(float direction, float deltaTime) 
        {
            if (direction == 0)
                throw new InvalidOperationException(nameof(direction));

            direction = direction > 0 ? 1 : -1;

            _ship.Rotate(direction * deltaTime * _degreesPerSecond);
        }
    }
}

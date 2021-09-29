using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class Trajectory : Transformable
    {
        public readonly float Speed;
        public readonly Vector2 StartPosition;
        public readonly Vector2 Direction;

        private readonly Func<Trajectory, float> _currentTimeProvider;
        
        public override Vector2 Position => StartPosition + (Direction * Speed * _currentTimeProvider.Invoke(this));

        public Trajectory(float speed, Vector2 startPosition, Vector2 direction, Func<Trajectory, float> currentTimeProvider) 
            : base(startPosition, Vector2.SignedAngle(Vector3.up, direction))
        {
            StartPosition = startPosition;
            Direction = direction;
            Speed = speed;
            _currentTimeProvider = currentTimeProvider;
        }
    }
}

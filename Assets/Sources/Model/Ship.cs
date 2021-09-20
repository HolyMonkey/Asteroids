using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class Ship 
    {
        public Ship(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Vector2 Position { get; private set; }
        public float Rotation { get; private set; }

        public void MoveLooped(Vector2 delta)
        {
            var nextPosition = Position + delta;

            nextPosition.x = Mathf.Repeat(nextPosition.x, 1);
            nextPosition.y = Mathf.Repeat(nextPosition.y, 1);

            Position = nextPosition;
        }

        public void Rotate(float delta)
        {
            Rotation = Mathf.Repeat(Rotation + delta, 360);
        }
    }
}

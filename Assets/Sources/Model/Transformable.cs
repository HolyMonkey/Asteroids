using System;
using UnityEngine;

namespace Asteroids.Model
{
    public abstract class Transformable
    {
        public virtual Vector2 Position { get; private set; }
        public float Rotation { get; private set; }
        public Vector2 Forward => Quaternion.Euler(0, 0, Rotation) * Vector3.up;

        public event Action Moved;
        public event Action Rotated;
        public event Action Destroying;

        public Transformable(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public void Rotate(float delta)
        {
            Rotation = Mathf.Repeat(Rotation + delta, 360);
            Rotated?.Invoke();
        }

        public void MoveTo(Vector2 position)
        {
            Position = position;
            Moved?.Invoke();
        }

        public void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}

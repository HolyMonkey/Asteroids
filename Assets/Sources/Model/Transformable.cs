using UnityEngine;

namespace Asteroids.Model
{
    public abstract class Transformable
    {
        public virtual Vector2 Position { get; protected set; }
        public float Rotation { get; private set; }

        public Transformable(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public void Rotate(float delta)
        {
            Rotation = Mathf.Repeat(Rotation + delta, 360);
        }
    }
}

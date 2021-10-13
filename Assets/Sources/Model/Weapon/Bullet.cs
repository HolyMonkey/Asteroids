using UnityEngine;

namespace Asteroids.Model
{
    public abstract class Bullet : Transformable, IUpdatable
    {
        public readonly float Lifetime;
        public readonly float Speed;

        private float _accumulatedTime;

        protected Bullet(Vector2 position, float lifetime, float speed) : base(position, 0)
        {
            Lifetime = lifetime;
            Speed = speed;
        }

        public virtual void Update(float deltaTime)
        {
            _accumulatedTime += Time.deltaTime;

            if(_accumulatedTime >= Lifetime)
            {
                Destroy();
            }
        }
    }
}

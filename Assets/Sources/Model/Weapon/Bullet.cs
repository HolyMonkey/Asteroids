using UnityEngine;

namespace Asteroids.Model
{
    public abstract class Bullet : Transformable, IUpdatable
    {
        private readonly float _lifetime;
        private readonly float _speed;

        private float _accumulatedTime;

        protected Bullet(Vector2 position, float lifetime, float speed) : base(position, 0)
        {
            _lifetime = lifetime;
            _speed = speed;
        }

        public virtual void Update(float deltaTime)
        {
            _accumulatedTime += Time.deltaTime;

            if(_accumulatedTime >= _lifetime)
            {
                Destroy();
            }
        }
    }
}

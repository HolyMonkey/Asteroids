using System;
using System.Linq;
using System.Collections.Generic;

namespace Asteroids.Model
{ 
    public abstract class Simulation<T>
    {
        private List<PlacedEntity> _entities = new List<PlacedEntity>();

        public IEnumerable<PlacedEntity> Entities => _entities;

        public event Action<PlacedEntity> Start;
        public event Action<PlacedEntity> End;

        public abstract void Update(float deltaTime);

        protected void Simulate(PlacedEntity placedEntity)
        {
            _entities.Add(placedEntity);
            Start?.Invoke(placedEntity);
        }

        protected void Stop(PlacedEntity placedEntity)
        {
            _entities.Remove(placedEntity);
            End?.Invoke(placedEntity);
            OnStoped(placedEntity);
        }

        protected virtual void OnStoped(PlacedEntity placedEntity) { }

        public void StopAll(T model)
        {
            List<PlacedEntity> candidats = _entities.Where(entity => entity.Entity.Equals(model)).ToList();
            candidats.ForEach(Stop);
        }

        public class PlacedEntity
        {
            public readonly T Entity;
            public readonly Transformable Transform;

            public PlacedEntity(T entity, Transformable transform)
            {
                Entity = entity;
                Transform = transform;
            }
        }
    }
}

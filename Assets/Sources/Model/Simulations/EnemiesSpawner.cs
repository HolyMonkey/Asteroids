using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Model
{
    public class EnemiesSpawner
    {
        private readonly EnemiesSimulation _simulation;
        private readonly Transformable _player;

        private readonly Func<Func<Vector2>, Enemy>[] _variants;
        private readonly Timers<Func<Func<Vector2>, Enemy>> _queue = new Timers<Func<Func<Vector2>, Enemy>>();

        public EnemiesSpawner(EnemiesSimulation simulation, Transformable player)
        {
            _simulation = simulation;
            _player = player;

            _variants = new Func<Func<Vector2>, Enemy>[]
            {
                (positionProvider) => new Asteroid(positionProvider(), Random.insideUnitCircle.normalized, 0.05f),
                (positionProvider) => new Nlo(_player, positionProvider(), 0.05f)
            };
        }

        public void FillTestQueue()
        {
            for (int stacks = 0; stacks < 100; stacks++)
            {
                int countInStack = Random.Range(0, 5);

                while(countInStack-- > 0)
                    _queue.Start(_variants[0], stacks, (variant) => _simulation.Simulate(variant(GetRandomPositionOutsideScreen)));
            }

            _queue.Start(_variants[1], 1, (variant) => _simulation.Simulate(variant(GetRandomPositionOutsideScreen)));
            _queue.Start(_variants[1], 7, (variant) => _simulation.Simulate(variant(GetRandomPositionOutsideScreen)));
            _queue.Start(_variants[1], 7, (variant) => _simulation.Simulate(variant(GetRandomPositionOutsideScreen)));
            _queue.Start(_variants[1], 16, (variant) => _simulation.Simulate(variant(GetRandomPositionOutsideScreen)));
            _queue.Start(_variants[1], 25, (variant) => _simulation.Simulate(variant(GetRandomPositionOutsideScreen)));
        }

        public void Update(float deltaTime)
        {
            _queue.Tick(deltaTime);
        }

        private Vector2 GetRandomPositionOutsideScreen()
        {
            return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
        }
    }
}

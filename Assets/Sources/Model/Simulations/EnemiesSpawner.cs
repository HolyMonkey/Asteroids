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

        private readonly Func<Enemy>[] _variants;
        private readonly Timers<Func<Enemy>> _queue = new Timers<Func<Enemy>>();

        public EnemiesSpawner(EnemiesSimulation simulation, Transformable player)
        {
            _simulation = simulation;
            _player = player;

            _variants = new Func<Enemy>[]
            {
                CreateAsteroid,
                CreateNlo
            };
        }

        public void FillTestQueue()
        {
            for (int stacks = 0; stacks < 100; stacks++)
            {
                int countInStack = Random.Range(0, 2);

                while(countInStack-- > 0)
                    _queue.Start(_variants[0], stacks * 2, (factory) => _simulation.Simulate(factory.Invoke()));
            }

            _queue.Start(_variants[1], 1, (factory) => _simulation.Simulate(factory.Invoke()));
            _queue.Start(_variants[1], 7, (factory) => _simulation.Simulate(factory.Invoke()));
            _queue.Start(_variants[1], 7, (factory) => _simulation.Simulate(factory.Invoke()));
            _queue.Start(_variants[1], 16, (factory) => _simulation.Simulate(factory.Invoke()));
            _queue.Start(_variants[1], 25, (factory) => _simulation.Simulate(factory.Invoke()));
        }

        public void Update(float deltaTime)
        {
            _queue.Tick(deltaTime);
        }

        private Vector2 GetRandomPositionOutsideScreen()
        {
            return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
        }

        private Nlo CreateNlo()
        {
            return new Nlo(_player, GetRandomPositionOutsideScreen(), Config.NloSpeed);
        }

        private Asteroid CreateAsteroid()
        {
            Vector2 postion = GetRandomPositionOutsideScreen();
            Vector2 direction = GetDirectionThroughtScreen(postion);

            return new Asteroid(postion, direction, Config.AsteroidSpeed);
        }

        private static Vector2 GetDirectionThroughtScreen(Vector2 postion)
        {
            return (new Vector2(Random.value, Random.value) - postion).normalized;
        }
    }
}

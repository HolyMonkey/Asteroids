using System;
using System.Collections.Generic;
using static Asteroids.Model.PhysicsRouter;

namespace Asteroids.Model
{
    public class CollisionsRecords
    {
        private readonly BulletsSimulation _bullets;
        private readonly EnemiesSimulation _enemies;

        public event Action GameEnd;

        public CollisionsRecords(BulletsSimulation bullets, EnemiesSimulation enemies)
        {
            _bullets = bullets;
            _enemies = enemies;
        }

        public IEnumerable<Record> Values()
        {
            yield return IfCollided((Bullet bullet, Enemy enemy) =>
            {
                _enemies.StopAll(enemy);
            });

            yield return IfCollided((DefaultBullet bullet, Enemy enemy) =>
            {
                _bullets.StopAll(bullet);
            });

            yield return IfCollided((Bullet bullet, Asteroid asteroid) =>
            {
                if (asteroid is PartOfAsteroid)
                    return;

                _enemies.Simulate(asteroid.CreatePart());
                _enemies.Simulate(asteroid.CreatePart());
                _enemies.Simulate(asteroid.CreatePart());
                _enemies.Simulate(asteroid.CreatePart());
            });

            yield return IfCollided((Ship ship, Enemy enemy) =>
            {
                GameEnd?.Invoke();
            });
        }

        private Record IfCollided<T1, T2>(Action<T1, T2> action)
        {
            return new Record<T1, T2>(action);
        }
    }
}

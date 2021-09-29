using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Model
{
    public class PhysicsRouter
    {
        private Collisions _collisions = new Collisions();

        private readonly Func<IEnumerable<Record>> _recordsProvider;

        public PhysicsRouter(Func<IEnumerable<Record>> recordsProvider)
        {
            _recordsProvider = recordsProvider;
        }

        public void TryAddCollision(object modelA, object modelB)
        {
            _collisions.TryBind(modelA, modelB);
        }

        public void Step()
        {
            foreach (var pair in _collisions.Pairs)
                TryRoute(pair);

            _collisions = new Collisions();
        }

        public void TryRoute((object, object) pair)
        {
            IEnumerable<Record> records = _recordsProvider?.Invoke().Where(record => record.IsTarget(pair));

            foreach (var record in records)
                ((dynamic)record).Do((dynamic)pair.Item1, (dynamic)pair.Item2);
        }

        public abstract class Record 
        {
            public abstract bool IsTarget((object, object) pair);
        }

        public sealed class Record<T1, T2> : Record
        {
            public readonly Action<T1, T2> Action;

            public Record(Action<T1, T2> action)
            {
                Action = action;
            }

            public void Do(T1 a, T2 b)
            {
                Action(a, b);
            }

            public void Do(T2 b, T1 a)
            {
                Action(a, b);
            }

            public override bool IsTarget((object, object) pair)
            {
                if (pair.Item1 is T1 && pair.Item2 is T2)
                    return true;

                if (pair.Item1 is T2 && pair.Item2 is T1)
                    return true;

                return false;
            }
        }

        private class Collisions
        {
            private List<(object, object)> _pairs = new List<(object, object)>();

            public IEnumerable<(object, object)> Pairs => _pairs;

            public void TryBind(object a, object b)
            {
                foreach (var (left, right) in _pairs)
                {
                    if (left == a && right == b)
                        return;

                    if (left == b && right == a)
                        return;
                }

                _pairs.Add((a, b));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Model
{
    class Timers<T>
    {
        private List<Timer> _timers = new List<Timer>();

        public void Start(T context, float time, Action<T> onEnd)
        {
            _timers.Add(new Timer(context, time, onEnd));
        }

        public void StopAll (T context)
        {
            _timers.RemoveAll(timer => timer.Context.Equals(context));
        }

        public void Tick(float deltaTime)
        {
            foreach (var timer in _timers.ToList())
            {
                timer.AccumulatedTime += deltaTime;
            
                if(timer.IsEnd)
                {
                    _timers.Remove(timer);
                    timer.OnEnd.Invoke(timer.Context);
                }
            }
        }

        public float GetAccumulatedTime(T context)
        {
            return _timers.First(timer => timer.Context.Equals(context)).AccumulatedTime;
        }

        private class Timer
        {
            public float AccumulatedTime;
            public readonly float Time;
            public readonly T Context;
            public readonly Action<T> OnEnd;

            public bool IsEnd => Time <= AccumulatedTime;

            public Timer(T context, float time, Action<T> onEnd)
            {
                Time = time;
                Context = context;
                OnEnd = onEnd;
            }
        }
    }
}

using System;
using Tarject.Runtime.SignalBus.Model;
using Tarject.Runtime.StructuralDefinitions;

namespace Tarject.Runtime.SignalBus.Controller
{
    public sealed class SignalController
    {
        private readonly OptimizedList<Subscriber> _subscribers = new OptimizedList<Subscriber>();

        public void Subscribe<T>(Action<T> action)
        {
            _subscribers.Add(new Subscriber(action, typeof(T)));
        }

        public void Unsubscribe<T>(Action<T> action)
        {
            for (int index = 0; index < _subscribers.Count; index++)
            {
                if (_subscribers[index].Delegate as Action<T> == action)
                {
                    _subscribers.RemoveAt(index);
                }
            }
        }

        public void Fire<T>(T signal)
        {
            for (int index = 0; index < _subscribers.Count; index++)
            {
                if (_subscribers[index].Type == typeof(T))
                {
                    ((Action<T>)_subscribers[index].Delegate)?.Invoke(signal);
                }
            }
        }
    }
}
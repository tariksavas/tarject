using System;

namespace Tarject.Runtime.SignalBus.Model
{
    public struct Subscriber
    {
        public Delegate Delegate;
        public Type Type;

        public Subscriber(Delegate @delegate, Type type)
        {
            Delegate = @delegate;
            Type = type;
        }
    }
}
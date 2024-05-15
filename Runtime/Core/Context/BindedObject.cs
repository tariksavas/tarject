using System;

namespace Tarject.Runtime.Core.Context
{
    public class BindedObject
    {
        public readonly object CreatedObject;

        public readonly Type Type;

        public Type InterfaceType;

        public string Id;

        private bool _withTriggerableInterfaces;

        public BindedObject(Type type, object createdObject)
        {
            Type = type;
            CreatedObject = createdObject;
        }

        public T GetTriggerableInterface<T>() where T : class
        {
            if (!_withTriggerableInterfaces)
            {
                return null;
            }

            return CreatedObject is T t
                ? t
                : null;
        }

        public BindedObject WithTriggerableInterfaces()
        {
            _withTriggerableInterfaces = true;

            return this;
        }

        public BindedObject ToInterface<T>() where T : class
        {
            InterfaceType = typeof(T);

            return this;
        }

        public BindedObject WithId(string id)
        {
            Id = id;

            return this;
        }
    }
}
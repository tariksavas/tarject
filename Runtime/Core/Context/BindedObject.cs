using System;

namespace Tarject.Runtime.Core.Context
{
    public class BindedObject
    {
        public readonly object CreatedObject;

        public readonly Type Type;

        public readonly bool Initialized;

        public Type InterfaceType { get; private set; }

        public string Id { get; private set; }

        public BindedObject(Type type, object createdObject, bool initialized = true)
        {
            Type = type;
            CreatedObject = createdObject;
            Initialized = initialized;
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
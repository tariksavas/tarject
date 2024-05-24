using System;

namespace Tarject.Runtime.Core.Context
{
    public class BindedObject
    {
        public readonly object CreatedObject;

        public readonly Type Type;

        public Type InterfaceType;

        public string Id;

        public BindedObject(Type type, object createdObject)
        {
            Type = type;
            CreatedObject = createdObject;
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
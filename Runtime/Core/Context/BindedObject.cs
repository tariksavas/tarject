using System;

namespace Tarject.Runtime.Core.Context
{
    public class BindedObject
    {
        public readonly Type Type;

        public object CreatedObject { get; set; }

        public Type InterfaceType { get; private set; }

        public string Id { get; private set; }

        public bool IsLazy { get; private set; }

        public BindedObject(Type type, object createdObject = null)
        {
            Type = type;
            CreatedObject = createdObject;
        }

        public BindedObject Lazy()
        {
            IsLazy = true;
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
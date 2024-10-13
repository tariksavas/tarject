using System;

namespace Tarject.Runtime.Core.Context
{
    public class BindedFactory : BindedObject
    {
        private readonly DIContainer _container;

        public BindedFactory(Type type, DIContainer container) : base(type)
        {
            _container = container;
        }

        public void InitializeFactory()
        {
            Factory.Factory factory = (Factory.Factory)CreatedObject;
            factory.SetContainer(_container);
        }
    }
}
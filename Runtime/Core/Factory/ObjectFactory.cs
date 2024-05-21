using System;
using Tarject.Runtime.Utility;

namespace Tarject.Runtime.Core.Factory
{
    public class ObjectFactory : Factory
    {
        public object Create<T>() where T : class
        {
            Type type = typeof(T);

            object[] injectableParameterObjects = type.GetInjectableParameterObjects(_context);

            object createdObject = Activator.CreateInstance(type, injectableParameterObjects);

            return createdObject;
        }

        public object Create<T>(params object[] parameters) where T : class
        {
            object createdObject = Create<T>();

            createdObject.InitializeFactory(parameters);

            return createdObject;
        }
    }
}
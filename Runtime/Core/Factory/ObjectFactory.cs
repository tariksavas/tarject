using System;
using Tarject.Runtime.Utility;

namespace Tarject.Runtime.Core.Factory
{
    public class ObjectFactory : Factory
    {
        public TFactory Create<TFactory>()
            where TFactory : IFactory
        {
            Type type = typeof(TFactory);

            object[] injectableParameterObjects = type.GetInjectableParameterObjects(_container);

            return (TFactory)Activator.CreateInstance(type, injectableParameterObjects);
        }

        public TFactory Create<TFactory, TParam1>(TParam1 param1)
            where TFactory : IFactory<TParam1>
        {
            TFactory createdObject = Create<TFactory>();

            createdObject.InitializeFactory(param1);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2>(TParam1 param1, TParam2 param2)
            where TFactory : IFactory<TParam1, TParam2>
        {
            TFactory createdObject = Create<TFactory>();

            createdObject.InitializeFactory(param1, param2);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactory : IFactory<TParam1, TParam2, TParam3>
        {
            TFactory createdObject = Create<TFactory>();

            createdObject.InitializeFactory(param1, param2, param3);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2, TParam3, TParam4>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactory : IFactory<TParam1, TParam2, TParam3, TParam4>
        {
            TFactory createdObject = Create<TFactory>();

            createdObject.InitializeFactory(param1, param2, param3, param4);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2, TParam3, TParam4, TParam5>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactory : IFactory<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            TFactory createdObject = Create<TFactory>();

            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            return createdObject;
        }
    }
}
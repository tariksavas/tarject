using System;
using Tarject.Runtime.Utility;

namespace Tarject.Runtime.Core.Factory
{
    public class ObjectFactory : Factory
    {
        public TFactorable Create<TFactorable>()
            where TFactorable : IFactorable
        {
            Type type = typeof(TFactorable);

            return type.TryGetDependencies(out object[] injectableParameterObjects, _container)
                ? (TFactorable)Activator.CreateInstance(type, injectableParameterObjects)
                : (TFactorable)Activator.CreateInstance(type);
        }

        public TFactorable Create<TFactorable, TParam1>(TParam1 param1)
            where TFactorable : IFactorable<TParam1>
        {
            TFactorable createdObject = Create<TFactorable>();

            createdObject.InitializeFactory(param1);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2>(TParam1 param1, TParam2 param2)
            where TFactorable : IFactorable<TParam1, TParam2>
        {
            TFactorable createdObject = Create<TFactorable>();

            createdObject.InitializeFactory(param1, param2);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactorable : IFactorable<TParam1, TParam2, TParam3>
        {
            TFactorable createdObject = Create<TFactorable>();

            createdObject.InitializeFactory(param1, param2, param3);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactorable : IFactorable<TParam1, TParam2, TParam3, TParam4>
        {
            TFactorable createdObject = Create<TFactorable>();

            createdObject.InitializeFactory(param1, param2, param3, param4);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4, TParam5>(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactorable : IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            TFactorable createdObject = Create<TFactorable>();

            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            return createdObject;
        }
    }
}
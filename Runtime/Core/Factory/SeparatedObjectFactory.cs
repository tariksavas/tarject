using System;
using Tarject.Runtime.Utility;

namespace Tarject.Runtime.Core.Factory
{
    public abstract class SeparatedObjectFactory<TFactorable> : Factory
            where TFactorable : IFactorable
    {
        public TFactorable Create()
        {
            Type type = typeof(TFactorable);

            return type.TryGetDependencies(out object[] injectableParameterObjects, _container)
                ? (TFactorable)Activator.CreateInstance(type, injectableParameterObjects)
                : (TFactorable)Activator.CreateInstance(type);
        }
    }

    public abstract class SeparatedObjectFactory<TFactorable, TParam> : SeparatedObjectFactory<TFactorable>
            where TFactorable : IFactorable<TParam>
    {
        public TFactorable Create(TParam param)
        {
            TFactorable createdObject = Create();

            createdObject.InitializeFactory(param);

            return createdObject;
        }
    }

    public abstract class SeparatedObjectFactory<TFactorable, TParam1, TParam2> : SeparatedObjectFactory<TFactorable>
            where TFactorable : IFactorable<TParam1, TParam2>
    {
        public TFactorable Create(TParam1 param1, TParam2 param2)
        {
            TFactorable createdObject = Create();

            createdObject.InitializeFactory(param1, param2);

            return createdObject;
        }
    }

    public abstract class SeparatedObjectFactory<TFactorable, TParam1, TParam2, TParam3> : SeparatedObjectFactory<TFactorable>
            where TFactorable : IFactorable<TParam1, TParam2, TParam3>
    {
        public TFactorable Create(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            TFactorable createdObject = Create();

            createdObject.InitializeFactory(param1, param2, param3);

            return createdObject;
        }
    }

    public abstract class SeparatedObjectFactory<TFactorable, TParam1, TParam2, TParam3, TParam4> : SeparatedObjectFactory<TFactorable>
            where TFactorable : IFactorable<TParam1, TParam2, TParam3, TParam4>
    {
        public TFactorable Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
        {
            TFactorable createdObject = Create();

            createdObject.InitializeFactory(param1, param2, param3, param4);

            return createdObject;
        }
    }

    public abstract class SeparatedObjectFactory<TFactorable, TParam1, TParam2, TParam3, TParam4, TParam5> : SeparatedObjectFactory<TFactorable>
            where TFactorable : IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
    {
        public TFactorable Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
        {
            TFactorable createdObject = Create();

            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            return createdObject;
        }
    }
}
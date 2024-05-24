using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Factory
{
    public class GameObjectFactory : Factory
    {
        public TFactory Create<TFactory>(TFactory prefab)
            where TFactory : Component, IFactory
        {
            TFactory createdObject = Object.Instantiate(prefab);

            createdObject.InjectToFields(_context);

            if (createdObject.TryGetComponent(out MonoInjecter monoInjecter))
            {
                monoInjecter.Injected = true;
            }

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1>(TFactory prefab, TParam1 param1)
            where TFactory : Component, IFactory<TParam1>
        {
            TFactory createdObject = Create(prefab);
            createdObject.InitializeFactory(param1);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2>(TFactory prefab, TParam1 param1, TParam2 param2)
            where TFactory : Component, IFactory<TParam1, TParam2>
        {
            TFactory createdObject = Create(prefab);
            createdObject.InitializeFactory(param1, param2);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2, TParam3>(TFactory prefab, TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactory : Component, IFactory<TParam1, TParam2, TParam3>
        {
            TFactory createdObject = Create(prefab);
            createdObject.InitializeFactory(param1, param2, param3);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2, TParam3, TParam4>(TFactory prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactory : Component, IFactory<TParam1, TParam2, TParam3, TParam4>
        {
            TFactory createdObject = Create(prefab);
            createdObject.InitializeFactory(param1, param2, param3, param4);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2, TParam3, TParam4, TParam5>(TFactory prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactory : Component, IFactory<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            TFactory createdObject = Create(prefab);
            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            return createdObject;
        }

        public TFactory Create<TFactory>(TFactory prefab, Transform parent)
            where TFactory : Component, IFactory
        {
            TFactory createdObject = Object.Instantiate(prefab, parent);

            createdObject.InjectToFields(_context);

            if (createdObject.TryGetComponent(out MonoInjecter monoInjecter))
            {
                monoInjecter.Injected = true;
            }

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1>(TFactory prefab, Transform parent, TParam1 param1) 
            where TFactory : Component, IFactory<TParam1>
        {
            TFactory createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2>(TFactory prefab, Transform parent, TParam1 param1, TParam2 param2)
            where TFactory : Component, IFactory<TParam1, TParam2>
        {
            TFactory createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1, param2);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2, TParam3>(TFactory prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactory : Component, IFactory<TParam1, TParam2, TParam3>
        {
            TFactory createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1, param2, param3);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2, TParam3, TParam4>(TFactory prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactory : Component, IFactory<TParam1, TParam2, TParam3, TParam4>
        {
            TFactory createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1, param2, param3, param4);

            return createdObject;
        }

        public TFactory Create<TFactory, TParam1, TParam2, TParam3, TParam4, TParam5>(TFactory prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactory : Component, IFactory<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            TFactory createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            return createdObject;
        }
    }
}
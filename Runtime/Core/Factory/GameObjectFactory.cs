using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Factory
{
    public class GameObjectFactory : Factory
    {
        public TFactorable Create<TFactorable>(TFactorable prefab)
            where TFactorable : Component, IFactorable
        {
            TFactorable createdObject = Object.Instantiate(prefab);

            createdObject.InjectToFields(_container);

            if (createdObject.TryGetComponent(out MonoInjecter monoInjecter))
            {
                monoInjecter.Injected = true;
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1>(TFactorable prefab, TParam1 param1)
            where TFactorable : Component, IFactorable<TParam1>
        {
            TFactorable createdObject = Create(prefab);
            createdObject.InitializeFactory(param1);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2>(TFactorable prefab, TParam1 param1, TParam2 param2)
            where TFactorable : Component, IFactorable<TParam1, TParam2>
        {
            TFactorable createdObject = Create(prefab);
            createdObject.InitializeFactory(param1, param2);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3>(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3>
        {
            TFactorable createdObject = Create(prefab);
            createdObject.InitializeFactory(param1, param2, param3);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4>(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4>
        {
            TFactorable createdObject = Create(prefab);
            createdObject.InitializeFactory(param1, param2, param3, param4);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4, TParam5>(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            TFactorable createdObject = Create(prefab);
            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            return createdObject;
        }

        public TFactorable Create<TFactorable>(TFactorable prefab, Transform parent)
            where TFactorable : Component, IFactorable
        {
            TFactorable createdObject = Object.Instantiate(prefab, parent);

            createdObject.InjectToFields(_container);

            if (createdObject.TryGetComponent(out MonoInjecter monoInjecter))
            {
                monoInjecter.Injected = true;
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1>(TFactorable prefab, Transform parent, TParam1 param1) 
            where TFactorable : Component, IFactorable<TParam1>
        {
            TFactorable createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2)
            where TFactorable : Component, IFactorable<TParam1, TParam2>
        {
            TFactorable createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1, param2);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3>
        {
            TFactorable createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1, param2, param3);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4>
        {
            TFactorable createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1, param2, param3, param4);

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4, TParam5>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            TFactorable createdObject = Create(prefab, parent);
            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            return createdObject;
        }
    }
}
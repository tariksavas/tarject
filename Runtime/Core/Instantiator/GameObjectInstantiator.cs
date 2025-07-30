using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Factory;
using UnityEngine;

namespace Tarject.Runtime.Core.Instantiator
{
    public class GameObjectInstantiator : IInstantiator
    {
        public T Create<T>(T prefab, Transform parent = null, bool preserveWorldScale = false, DIContainer container = null)
            where T : Component
        {
            T createdObject = StaticInstantiator.CreateHiddenObject(prefab, container, out bool setActiveAfterInitialization, parent);
            
            if (preserveWorldScale)
            {
                StaticInstantiator.PreserveWorldScale(createdObject.transform, prefab.transform.localScale);
            }
            
            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }
            
            return createdObject;
        }

        public T Create<T, TParam>(T prefab, TParam param, Transform parent = null, bool preserveWorldScale = false,
            DIContainer container = null) where T : Component, IFactorable<TParam>
        {
            T createdObject = StaticInstantiator.CreateHiddenObject(prefab, container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param);
            
            if (preserveWorldScale)
            {
                StaticInstantiator.PreserveWorldScale(createdObject.transform, prefab.transform.localScale);
            }
            
            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }
            
            return createdObject;
        }

        public T Create<T, TParam1, TParam2>(T prefab, TParam1 param1, TParam2 param2, Transform parent = null, 
            bool preserveWorldScale = false, DIContainer container = null) where T : Component, IFactorable<TParam1, TParam2>
        {
            T createdObject = StaticInstantiator.CreateHiddenObject(prefab, container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1, param2);
            
            if (preserveWorldScale)
            {
                StaticInstantiator.PreserveWorldScale(createdObject.transform, prefab.transform.localScale);
            }
            
            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }
            
            return createdObject;
        }

        public T Create<T, TParam1, TParam2, TParam3>(T prefab, TParam1 param1, TParam2 param2, TParam3 param3,
            Transform parent = null, bool preserveWorldScale = false, DIContainer container = null)
            where T : Component, IFactorable<TParam1, TParam2, TParam3>
        {
            T createdObject =
                StaticInstantiator.CreateHiddenObject(prefab, container, out bool setActiveAfterInitialization,
                    parent);
            createdObject.InitializeFactory(param1, param2, param3);
            
            if (preserveWorldScale)
            {
                StaticInstantiator.PreserveWorldScale(createdObject.transform, prefab.transform.localScale);
            }
            
            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }
            
            return createdObject;
        }

        public T Create<T, TParam1, TParam2, TParam3, TParam4>(T prefab, TParam1 param1, TParam2 param2, TParam3 param3,
            TParam4 param4, Transform parent = null, bool preserveWorldScale = false, DIContainer container = null)
            where T : Component, IFactorable<TParam1, TParam2, TParam3, TParam4>
        {
            T createdObject =
                StaticInstantiator.CreateHiddenObject(prefab, container, out bool setActiveAfterInitialization,
                    parent);
            createdObject.InitializeFactory(param1, param2, param3, param4);

            if (preserveWorldScale)
            {
                StaticInstantiator.PreserveWorldScale(createdObject.transform, prefab.transform.localScale);
            }
            
            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public T Create<T, TParam1, TParam2, TParam3, TParam4, TParam5>(T prefab, TParam1 param1, TParam2 param2,
            TParam3 param3, TParam4 param4, TParam5 param5, Transform parent = null, bool preserveWorldScale = false,
            DIContainer container = null) where T : Component, IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            T createdObject =
                StaticInstantiator.CreateHiddenObject(prefab, container, out bool setActiveAfterInitialization,
                    parent);
            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            if (preserveWorldScale)
            {
                StaticInstantiator.PreserveWorldScale(createdObject.transform, prefab.transform.localScale);
            }

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }
            
            return createdObject;
        }
    }
}
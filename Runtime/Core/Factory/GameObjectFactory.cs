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
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1>(TFactorable prefab, TParam1 param1)
            where TFactorable : Component, IFactorable<TParam1>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab);
            properties.CreatedObject.InitializeFactory(param1);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2>(TFactorable prefab, TParam1 param1, TParam2 param2)
            where TFactorable : Component, IFactorable<TParam1, TParam2>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab);
            properties.CreatedObject.InitializeFactory(param1, param2);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3>(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab);
            properties.CreatedObject.InitializeFactory(param1, param2, param3);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4>(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab);
            properties.CreatedObject.InitializeFactory(param1, param2, param3, param4);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4, TParam5>(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab);
            properties.CreatedObject.InitializeFactory(param1, param2, param3, param4, param5);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable>(TFactorable prefab, Transform parent)
            where TFactorable : Component, IFactorable
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab, parent);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1>(TFactorable prefab, Transform parent, TParam1 param1) 
            where TFactorable : Component, IFactorable<TParam1>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab, parent);
            properties.CreatedObject.InitializeFactory(param1);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2)
            where TFactorable : Component, IFactorable<TParam1, TParam2>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab, parent);
            properties.CreatedObject.InitializeFactory(param1, param2);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab, parent);
            properties.CreatedObject.InitializeFactory(param1, param2, param3);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab, parent);
            properties.CreatedObject.InitializeFactory(param1, param2, param3, param4);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4, TParam5>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            CreatedHiddenObjectProperties<TFactorable> properties = CreateHiddenObject(prefab, parent);
            properties.CreatedObject.InitializeFactory(param1, param2, param3, param4, param5);

            if (properties.PrefabWasActive)
            {
                properties.CreatedObject.gameObject.SetActive(true);
            }

            return properties.CreatedObject;
        }

        public CreatedHiddenObjectProperties<TFactorable> CreateHiddenObject<TFactorable>(TFactorable prefab, Transform parent = null) where TFactorable : Component, IFactorable
        {
            bool prefabWasActive = prefab.gameObject.activeSelf;

            prefab.gameObject.SetActive(false);

            TFactorable createdObject = Object.Instantiate(prefab, parent);
            createdObject.InjectToFields(_container);

            if (createdObject.TryGetComponent(out MonoInjecter monoInjecter))
            {
                monoInjecter.Injected = true;
            }

            if (prefabWasActive)
            {
                prefab.gameObject.SetActive(true);
            }

            return new CreatedHiddenObjectProperties<TFactorable>(createdObject, prefabWasActive);
        }

        public readonly struct CreatedHiddenObjectProperties<TFactorable> where TFactorable : Component, IFactorable
        {
            public readonly TFactorable CreatedObject;

            public readonly bool PrefabWasActive;

            public CreatedHiddenObjectProperties(TFactorable createdObject, bool prefabWasActive) : this()
            {
                CreatedObject = createdObject;
                PrefabWasActive = prefabWasActive;
            }
        }
    }
}
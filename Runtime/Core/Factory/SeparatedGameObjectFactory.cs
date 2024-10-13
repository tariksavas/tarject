using UnityEngine;

namespace Tarject.Runtime.Core.Factory
{
    public abstract class SeparatedGameObjectFactory<TFactorable> : Factory
            where TFactorable : Component, IFactorable
    {
        public TFactorable Create(TFactorable prefab)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create(TFactorable prefab, Transform parent)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }
    }

    public abstract class SeparatedGameObjectFactory<TFactorable, TParam> : Factory
            where TFactorable : Component, IFactorable<TParam>
    {
        public TFactorable Create(TFactorable prefab, TParam param)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create(TFactorable prefab, Transform parent, TParam param)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }
    }

    public abstract class SeparatedGameObjectFactory<TFactorable, TParam1, TParam2> : Factory
            where TFactorable : Component, IFactorable<TParam1, TParam2>
    {
        public TFactorable Create(TFactorable prefab, TParam1 param1, TParam2 param2)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param1, param2);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1, param2);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }
    }

    public abstract class SeparatedGameObjectFactory<TFactorable, TParam1, TParam2, TParam3> : Factory
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3>
    {
        public TFactorable Create(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param1, param2, param3);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1, param2, param3);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }
    }

    public abstract class SeparatedGameObjectFactory<TFactorable, TParam1, TParam2, TParam3, TParam4> : Factory
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4>
    {
        public TFactorable Create(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param1, param2, param3, param4);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1, param2, param3, param4);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }
    }

    public abstract class SeparatedGameObjectFactory<TFactorable, TParam1, TParam2, TParam3, TParam4, TParam5> : Factory
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
    {
        public TFactorable Create(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }
    }
}
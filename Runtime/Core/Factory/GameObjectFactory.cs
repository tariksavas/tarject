using System;
using UnityEngine;

namespace Tarject.Runtime.Core.Factory
{
    [Obsolete("Create a Factory class under each Factorable object that inherits the SeparatedGameObjectFactory. You can read the documentation for more details.")]
    public class GameObjectFactory : Factory
    {
        public TFactorable Create<TFactorable>(TFactorable prefab)
            where TFactorable : Component, IFactorable
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam>(TFactorable prefab, TParam param)
            where TFactorable : Component, IFactorable<TParam>
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2>(TFactorable prefab, TParam1 param1, TParam2 param2)
            where TFactorable : Component, IFactorable<TParam1, TParam2>
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param1, param2);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3>(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3>
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param1, param2, param3);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4>(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4>
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param1, param2, param3, param4);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4, TParam5>(TFactorable prefab, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable>(TFactorable prefab, Transform parent)
            where TFactorable : Component, IFactorable
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1>(TFactorable prefab, Transform parent, TParam1 param1)
            where TFactorable : Component, IFactorable<TParam1>
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2)
            where TFactorable : Component, IFactorable<TParam1, TParam2>
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1, param2);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3>
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1, param2, param3);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4>
        {
            TFactorable createdObject = Instatiator.CreateHiddenObject(prefab, _container, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1, param2, param3, param4);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2, TParam3, TParam4, TParam5>(TFactorable prefab, Transform parent, TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
            where TFactorable : Component, IFactorable<TParam1, TParam2, TParam3, TParam4, TParam5>
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
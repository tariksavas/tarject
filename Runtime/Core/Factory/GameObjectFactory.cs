using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Factory
{
    public class GameObjectFactory : Factory
    {
        private static GameObject _hiddenParentObject;

        public TFactorable Create<TFactorable>(TFactorable prefab)
            where TFactorable : Component, IFactorable
        {
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1>(TFactorable prefab, TParam1 param1)
            where TFactorable : Component, IFactorable<TParam1>
        {
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization);
            createdObject.InitializeFactory(param1);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1, TParam2>(TFactorable prefab, TParam1 param1, TParam2 param2)
            where TFactorable : Component, IFactorable<TParam1, TParam2>
        {
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization);
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
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization);
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
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization);
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
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization);
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
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization, parent);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable Create<TFactorable, TParam1>(TFactorable prefab, Transform parent, TParam1 param1)
            where TFactorable : Component, IFactorable<TParam1>
        {
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization, parent);
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
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization, parent);
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
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization, parent);
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
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization, parent);
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
            TFactorable createdObject = CreateHiddenObject(prefab, out bool setActiveAfterInitialization, parent);
            createdObject.InitializeFactory(param1, param2, param3, param4, param5);

            if (setActiveAfterInitialization)
            {
                createdObject.gameObject.SetActive(true);
            }

            return createdObject;
        }

        public TFactorable CreateHiddenObject<TFactorable>(TFactorable prefab, out bool setActiveAfterInitialization, Transform parent = null) where TFactorable : Component, IFactorable
        {
            setActiveAfterInitialization = prefab.gameObject.activeSelf;

            Transform tempParent = parent;

            if (setActiveAfterInitialization)
            {
#if UNITY_EDITOR
                tempParent = GetOrCreateHiddenParent();
#else
                prefab.gameObject.SetActive(false);
#endif
            }

            TFactorable createdObject = Object.Instantiate(prefab, tempParent);
            createdObject.InjectToFields(_container);

            if (createdObject.TryGetComponent(out MonoInjecter monoInjecter))
            {
                monoInjecter.Injected = true;
            }

            if (setActiveAfterInitialization)
            {
#if UNITY_EDITOR
                createdObject.gameObject.SetActive(false);
#else
                prefab.gameObject.SetActive(true);
#endif
            }

            if (createdObject.transform.parent != parent)
            {
                createdObject.transform.SetParent(parent, false);
            }

            return createdObject;
        }

        private Transform GetOrCreateHiddenParent()
        {
            if (_hiddenParentObject == null)
            {
                _hiddenParentObject = new GameObject("HiddenParentObject");
                _hiddenParentObject.hideFlags = HideFlags.HideAndDontSave;
                _hiddenParentObject.SetActive(false);

                if (Application.isPlaying)
                {
                    Object.DontDestroyOnLoad(_hiddenParentObject);
                }
            }

            return _hiddenParentObject.transform;
        }
    }
}
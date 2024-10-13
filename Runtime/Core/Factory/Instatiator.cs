using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Factory
{
    public static class Instatiator
    {
        private static GameObject _hiddenParentObject;

        public static TFactorable CreateHiddenObject<TFactorable>(TFactorable prefab, DIContainer dIContainer, out bool setActiveAfterInitialization, Transform parent = null) 
            where TFactorable : Component, IFactorable
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
            createdObject.InjectToFields(dIContainer);

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

        private static Transform GetOrCreateHiddenParent()
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

using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Instantiator
{
    public static class StaticInstantiator
    {
        private static GameObject _hiddenParentObject;

        public static T CreateHiddenObject<T>(T prefab, DIContainer container, out bool setActiveAfterInitialization, Transform parent = null)
            where T : Component
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

            T createdObject = Object.Instantiate(prefab, tempParent);
            
            container ??= parent == null 
                ? createdObject.gameObject.scene.GetSceneContainer()
                : parent.gameObject.scene.GetSceneContainer();
            
            createdObject.InjectToFields(container);

            if (createdObject is MonoInjecter monoInjecter)
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
            if (_hiddenParentObject != null)
            {
                return _hiddenParentObject.transform;
            }

            _hiddenParentObject = new GameObject("HiddenParentObject")
            {
                hideFlags = HideFlags.HideAndDontSave
            };
            
            _hiddenParentObject.SetActive(false);

            if (Application.isPlaying)
            {
                Object.DontDestroyOnLoad(_hiddenParentObject);
            }

            return _hiddenParentObject.transform;
        }

        public static void PreserveWorldScale(Transform transform, Vector3 targetScale)
        {
            if (transform.parent == null)
            {
                transform.localScale = targetScale;
                return;
            }

            Vector3 parentScale = transform.parent.lossyScale;
            transform.localScale = new Vector3(
                targetScale.x / parentScale.x,
                targetScale.y / parentScale.y,
                targetScale.z / parentScale.z
            );
        }
    }
}

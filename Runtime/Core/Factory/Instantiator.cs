﻿using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Factory
{
    public static class Instantiator
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

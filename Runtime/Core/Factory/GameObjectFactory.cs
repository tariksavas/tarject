using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Factory
{
    public class GameObjectFactory : Factory
    {
        public T Create<T>(T prefab) where T : MonoBehaviour
        {
            T createdObject = Object.Instantiate(prefab);

            return AssignInjections(createdObject);
        }
        
        public T Create<T>(T prefab, Transform parent) where T : MonoBehaviour
        {
            T createdObject = Object.Instantiate(prefab, parent);

            return AssignInjections(createdObject);
        }
        
        public T Create<T>(T prefab, Transform parent, bool worldPositionStays) where T : MonoBehaviour
        {
            T createdObject = Object.Instantiate(prefab, parent, worldPositionStays);

            return AssignInjections(createdObject);
        }
        
        public T Create<T>(T prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour
        {
            T createdObject = Object.Instantiate(prefab, position, rotation);

            return AssignInjections(createdObject);
        }
        
        public T Create<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : MonoBehaviour
        {
            T createdObject = Object.Instantiate(prefab, position, rotation, parent);

            return AssignInjections(createdObject);
        }

        public T Create<T>(T prefab, params object[] parameters) where T : MonoBehaviour
        {
            T createdObject = Create(prefab);

            createdObject.InitializeFactory(parameters);

            return createdObject;
        }

        public T Create<T>(T prefab, Transform parent, params object[] parameters) where T : MonoBehaviour
        {
            T createdObject = Create(prefab, parent);

            createdObject.InitializeFactory(parameters);

            return createdObject;
        }

        public T Create<T>(T prefab, Transform parent, bool worldPositionStays, params object[] parameters) where T : MonoBehaviour
        {
            T createdObject = Create(prefab, parent, worldPositionStays);

            createdObject.InitializeFactory(parameters);

            return createdObject;
        }

        public T Create<T>(T prefab, Vector3 position, Quaternion rotation, params object[] parameters) where T : MonoBehaviour
        {
            T createdObject = Create(prefab, position, rotation);

            createdObject.InitializeFactory(parameters);

            return createdObject;
        }

        public T Create<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent, params object[] parameters) where T : MonoBehaviour
        {
            T createdObject = Create(prefab, position, rotation, parent);

            createdObject.InitializeFactory(parameters);

            return createdObject;
        }

        private T AssignInjections<T>(T createdObject) where T : MonoBehaviour
        {
            createdObject.InjectToFields(_context);
            createdObject.InjectToMethods(_context);

            if (createdObject.TryGetComponent(out MonoInjecter monoInjecter))
            {
                monoInjecter.Injected = true;
            }

            return createdObject;
        }
    }
}
using Tarject.Runtime.StructuralDefinitions;
using System;
using Tarject.Runtime.Utility;

namespace Tarject.Runtime.Core.Context
{
    public class DIContainer
    {
        private readonly OptimizedList<BindedObject> _bindedObjects = new OptimizedList<BindedObject>();

        private DIContainer _parentDIContainer;

        public void SetParentContainer(DIContainer parentDIContainer)
        {
            _parentDIContainer = parentDIContainer;
        }

        public BindedObject Bind<T>() where T : class
        {
            Type type = typeof(T);

            BindedObject bindedObject = new BindedObject(type);
            _bindedObjects.Add(bindedObject);

            return bindedObject;
        }

        public BindedObject BindFromInstance<T>(object instance) where T : class
        {
            Type type = typeof(T);

            BindedObject bindedObject = new BindedObject(type, instance);
            _bindedObjects.Add(bindedObject);

            return bindedObject;
        }

        public BindedObject BindFromHierarchy<T>() where T : UnityEngine.Object
        {
            Type type = typeof(T);

            object instance = UnityEngine.Object.FindAnyObjectByType<T>();

            BindedObject bindedObject = new BindedObject(type, instance);
            _bindedObjects.Add(bindedObject);

            return bindedObject;
        }

        public BindedObject BindFactory<T>() where T : Factory.Factory
        {
            Type type = typeof(T);

            object createdObject = Activator.CreateInstance(type);

            ((T)createdObject).SetContainer(this);

            BindedObject bindedObject = new BindedObject(type, createdObject);
            _bindedObjects.Add(bindedObject);

            return bindedObject;
        }

        public void CompleteBindings()
        {
            for (int index = 0; index < _bindedObjects.Count; index++)
            {
                BindedObject bindedObject = _bindedObjects[index];
                if (bindedObject == null || bindedObject.IsLazy)
                {
                    continue;
                }

                TryCreateBindedObject(bindedObject);
            }
        }

        public T Resolve<T>(Type type = null, string id = "") where T : class
        {
            type ??= typeof(T);

            Predicate<BindedObject> predicate = string.IsNullOrEmpty(id)
                ? x => x.Type == type || x.InterfaceType == type
                : x => x.Id == id && (x.Type == type || x.InterfaceType == type);

            BindedObject bindedObject = _bindedObjects.Find(predicate);
            if (bindedObject == null)
            {
                return _parentDIContainer?.Resolve<T>(type, id);
            }

            TryCreateBindedObject(bindedObject);

            return bindedObject.CreatedObject as T;
        }

        public T[] ResolveAll<T>(Type type = null, string id = "") where T : class
        {
            type ??= typeof(T);

            Predicate<BindedObject> predicate = string.IsNullOrEmpty(id)
                ? x => x.Type == type || x.InterfaceType == type
                : x => x.Id == id && (x.Type == type || x.InterfaceType == type);

            OptimizedList<BindedObject> bindedObjects = _bindedObjects.FindAll(predicate);
            if (bindedObjects == null || bindedObjects.Count == 0)
            {
                return _parentDIContainer?.ResolveAll<T>(type, id);
            }

            T[] createdObjects = new T[bindedObjects.Count];

            for (int index = 0; index < bindedObjects.Count; index++)
            {
                TryCreateBindedObject(bindedObjects[index]);

                createdObjects[index] = bindedObjects[index].CreatedObject as T;
            }

            return createdObjects;
        }

        private void TryCreateBindedObject(BindedObject bindedObject)
        {
            if (bindedObject.CreatedObject != null || !bindedObject.Type.TryGetDependencies(out object[] objects, this))
            {
                return;
            }

            bindedObject.CreatedObject = objects.Length > 0
                ? Activator.CreateInstance(bindedObject.Type, objects)
                : Activator.CreateInstance(bindedObject.Type);
        }

        public OptimizedList<T> GetObjectsOfType<T>() where T : class
        {
            OptimizedList<T> result = new OptimizedList<T>();

            for (int index = 0; index < _bindedObjects.Count; index++)
            {
                if (_bindedObjects[index].CreatedObject is T t)
                {
                    result.Add(t);
                }
            }

            return result;
        }
    }
}
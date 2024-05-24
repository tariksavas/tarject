using Tarject.Runtime.StructuralDefinitions;
using System;
using Tarject.Runtime.Utility;
using System.Runtime.Serialization;
using System.Reflection;

namespace Tarject.Runtime.Core.Context
{
    public class DIContainer
    {
        private readonly OptimizedList<BindedObject> _bindedObjects = new OptimizedList<BindedObject>();

        public BindedObject Bind<T>() where T : class
        {
            Type type = typeof(T);

            object createdObject;

            ConstructorInfo constructorInfo = type.GetInjectableConstructor();
            if (constructorInfo == null)
            {
                createdObject = Activator.CreateInstance(type);
            }
            else
            {
                createdObject = FormatterServices.GetUninitializedObject(type);
            }

            BindedObject bindedObject = new BindedObject(type, createdObject);

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

            ((T)createdObject).SetContext(this.GetContainerContext());

            BindedObject bindedObject = new BindedObject(type, createdObject);

            _bindedObjects.Add(bindedObject);

            return bindedObject;
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
                return null;
            }

            return bindedObject.CreatedObject as T;
        }

        public void InjectConstructorsAfterBindings(Context context)
        {
            for (int index = 0; index < _bindedObjects.Count; index++)
            {
                _bindedObjects[index].CreatedObject.InjectToConstructor(context);
            }
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
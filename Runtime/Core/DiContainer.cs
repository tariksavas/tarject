using Tarject.Runtime.StructuralDefinitions;
using System;

namespace Tarject.Runtime.Core
{
    public class DiContainer
    {
        public static OptimizedList<object> objects = new OptimizedList<object> ();

        public static OptimizedList<object> iObjects = new OptimizedList<object>();

        public static void Bind<T>() where T : class
        {
            objects.Add(Activator.CreateInstance(typeof(T)));
        }

        public static void BindWithInterfaces<T>() where T : class
        {
            object obj = Activator.CreateInstance(typeof(T));

            objects.Add(obj);
            iObjects.Add(obj);
        }

        public static object GetInjection(Type type)
        {
            return objects.Find(x => x.GetType() == type);
        }
    }
}
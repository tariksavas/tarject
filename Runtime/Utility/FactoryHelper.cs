using System.Reflection;
using System;

namespace Tarject.Runtime.Utility
{
    public static class FactoryHelper
    {
        public static void InitializeFactory(this object createdObject, params object[] parameters)
        {
            const string methodName = "InitializeFactory";

            Type type = createdObject.GetType();
            MethodInfo method = type.GetMethod(methodName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            if (method == null)
            {
                return;
            }

            method.Invoke(createdObject, parameters);
        }
    }
}

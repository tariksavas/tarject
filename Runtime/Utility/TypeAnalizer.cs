using Tarject.Runtime.Core;
using System;
using System.Reflection;

namespace Tarject.Runtime.Utility
{
    public static class TypeAnalizer
    {
        public static void AssignInjectionToFields(this object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];

                if (Attribute.IsDefined(field, typeof(Inject)))
                {
                    field.SetValue(obj, DiContainer.GetInjection(field.FieldType));
                }
            }
        }

        public static void AssignInjectionToMethods(this object obj, string methodName)
        {
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod(methodName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            if (method == null)
            {
                return;
            }

            if (Attribute.IsDefined(method, typeof(Inject)))
            {
                object[] objects = Array.Empty<object>();

                ParameterInfo[] parameters = method.GetParameters();
                for (int j = 0; j < parameters.Length; j++)
                {
                    ParameterInfo parameter = parameters[j];
                    Type parameterType = parameter.ParameterType;
                    object parameterObject = DiContainer.GetInjection(parameterType);

                    Array.Resize(ref objects, objects.Length + 1);
                    objects[^1] = parameterObject;
                }

                method.Invoke(obj, objects);
            }
        }

        public static Type[] GetInterfaces(this object obj)
        {
            return obj.GetType().GetInterfaces();
        }

        public static bool DerivesFromOrEqual(this Type a, Type b)
        {
            return b == a || b.IsAssignableFrom(a);
        }
    }
}
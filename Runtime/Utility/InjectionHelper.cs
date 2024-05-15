using Tarject.Runtime.Core;
using System;
using System.Reflection;
using Tarject.Runtime.Core.Context;

namespace Tarject.Runtime.Utility
{
    public static class InjectionHelper
    {
        public static ConstructorInfo GetInjectableConstructor(this Type type)
        {
            ConstructorInfo[] constructorInfos = type.GetConstructors(
               BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            if (constructorInfos == null || constructorInfos.Length == 0)
            {
                return null;
            }

            ConstructorInfo injectedConstructorInfo = null;
            ConstructorInfo orderedConstructorInfo = null;

            for (int constructorIndex = 0; constructorIndex < constructorInfos.Length; constructorIndex++)
            {
                ConstructorInfo constructorInfo = constructorInfos[constructorIndex];

                if (Attribute.IsDefined(constructorInfo, typeof(Inject)))
                {
                    injectedConstructorInfo = constructorInfo;
                    break;
                }

                if (!constructorInfo.IsPublic || constructorInfo.GetParameters().Length == 0)
                {
                    continue;
                }

                if (orderedConstructorInfo == null ||
                    constructorInfo.GetParameters().Length > orderedConstructorInfo.GetParameters().Length)
                {
                    orderedConstructorInfo = constructorInfo;
                }
            }

            return injectedConstructorInfo != null
                ? injectedConstructorInfo
                : orderedConstructorInfo;
        }

        public static void InjectToConstructor(this object createdObject, Context context)
        {
            Type type = createdObject.GetType();
            ConstructorInfo constructorInfo = type.GetInjectableConstructor();
            if (constructorInfo == null)
            {
                return;
            }

            object[] objects = Array.Empty<object>();

            ParameterInfo[] parameters = constructorInfo.GetParameters();
            for (int parameterIndex = 0; parameterIndex < parameters.Length; parameterIndex++)
            {
                ParameterInfo parameter = parameters[parameterIndex];
                Type parameterType = parameter.ParameterType;

                Inject injectAttribute = parameter.GetCustomAttribute<Inject>();
                object parameterObject = context.Resolve<object>(parameterType, injectAttribute?.Id);

                Array.Resize(ref objects, objects.Length + 1);
                objects[^1] = parameterObject;
            }

            constructorInfo.Invoke(createdObject, objects);
        }

        public static void InjectToFields(this object obj, Context context)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            for (int index = 0; index < fields.Length; index++)
            {
                FieldInfo field = fields[index];

                if (Attribute.IsDefined(field, typeof(Inject)))
                {
                    Inject injectAttribute = field.GetCustomAttribute<Inject>();
                    field.SetValue(obj, context.Resolve<object>(field.FieldType, injectAttribute?.Id));
                }
            }
        }

        public static void InjectToMethods(this object createdObject, Context context)
        {
            const string methodName = "Inject";

            Type type = createdObject.GetType();
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

                    Inject injectAttribute = parameter.GetCustomAttribute<Inject>();
                    object parameterObject = context.Resolve<object>(parameterType, injectAttribute?.Id);

                    Array.Resize(ref objects, objects.Length + 1);
                    objects[^1] = parameterObject;
                }

                method.Invoke(createdObject, objects);
            }
        }
    }
}
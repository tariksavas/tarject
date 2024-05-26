using System;
using System.Reflection;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Injecter;

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

            ConstructorInfo injectableConstructorInfo = null;

            for (int constructorIndex = 0; constructorIndex < constructorInfos.Length; constructorIndex++)
            {
                ConstructorInfo constructorInfo = constructorInfos[constructorIndex];

                if (Attribute.IsDefined(constructorInfo, typeof(Inject)))
                {
                    injectableConstructorInfo = constructorInfo;
                    break;
                }

                if (!constructorInfo.IsPublic || constructorInfo.GetParameters().Length == 0)
                {
                    continue;
                }

                if (injectableConstructorInfo == null ||
                    constructorInfo.GetParameters().Length > injectableConstructorInfo.GetParameters().Length)
                {
                    injectableConstructorInfo = constructorInfo;
                }
            }

            return injectableConstructorInfo;
        }

        public static object[] GetInjectableParameterObjects(this Type type, DIContainer container)
        {
            object[] objects = Array.Empty<object>();

            ConstructorInfo constructorInfo = type.GetInjectableConstructor();
            if (constructorInfo == null)
            {
                return objects;
            }

            ParameterInfo[] parameters = constructorInfo.GetParameters();
            for (int parameterIndex = 0; parameterIndex < parameters.Length; parameterIndex++)
            {
                ParameterInfo parameter = parameters[parameterIndex];
                Type parameterType = parameter.ParameterType;

                Inject injectAttribute = parameter.GetCustomAttribute<Inject>();
                object parameterObject = container.Resolve<object>(parameterType, injectAttribute?.Id);

                Array.Resize(ref objects, objects.Length + 1);
                objects[^1] = parameterObject;
            }

            return objects;
        }

        public static void InjectToConstructor(this object createdObject, DIContainer container)
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
                object parameterObject = container.Resolve<object>(parameterType, injectAttribute?.Id);

                Array.Resize(ref objects, objects.Length + 1);
                objects[^1] = parameterObject;
            }

            constructorInfo.Invoke(createdObject, objects);
        }

        public static void InjectToFields(this object createdObject, DIContainer container)
        {
            Type type = createdObject.GetType();
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            for (int fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
            {
                FieldInfo field = fields[fieldIndex];

                if (Attribute.IsDefined(field, typeof(Inject)))
                {
                    Inject injectAttribute = field.GetCustomAttribute<Inject>();
                    field.SetValue(createdObject, container.Resolve<object>(field.FieldType, injectAttribute?.Id));
                }
            }
        }
    }
}
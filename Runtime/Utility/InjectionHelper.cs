using System;
using System.Reflection;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Injecter;
using UnityEngine;

namespace Tarject.Runtime.Utility
{
    public static class InjectionHelper
    {
        public static bool TryGetDependencies(this Type type, out object[] objects, DIContainer container)
        {
            objects = Array.Empty<object>();

            ConstructorInfo constructorInfo = type.GetCachedInjectableConstructor();
            if (constructorInfo == null)
            {
                return true;
            }

            ParameterInfo[] parameters = constructorInfo.GetCachedParameters();

            for (int parameterIndex = 0; parameterIndex < parameters.Length; parameterIndex++)
            {
                ParameterInfo parameter = parameters[parameterIndex];
                Type parameterType = parameter.ParameterType;

                InjectAttribute injectAttribute = parameter.GetCustomAttribute<InjectAttribute>();

                if (!parameterType.IsArray)
                {
                    object parameterObject = container.Resolve<object>(parameterType, injectAttribute?.Id);
                    if (parameterObject == null)
                    {
                        Debug.LogError($"Can not resolve depenceny! Type: {type} --- DependencyType: {parameterType}");
                        return false;
                    }

                    Array.Resize(ref objects, objects.Length + 1);
                    objects[^1] = parameterObject;
                }
                else
                {
                    Type elementType = parameterType.GetElementType();

                    object[] parameterObjects = container.ResolveAll<object>(elementType, injectAttribute?.Id);
                    if (parameterObjects == null)
                    {
                        Debug.LogError($"Can not resolve depenceny! Type: {type} --- DependencyType: {elementType}");
                        return false;
                    }

                    Array parameterArray = Array.CreateInstance(elementType, parameterObjects.Length);

                    for (int index = 0; index < parameterObjects.Length; index++)
                    {
                        parameterArray.SetValue(parameterObjects[index], index);
                    }

                    Array.Resize(ref objects, objects.Length + 1);
                    objects[^1] = parameterArray;
                }
            }

            return true;
        }

        public static void InjectToFields(this object createdObject, DIContainer container)
        {
            FieldInfo[] fields = createdObject.GetCachedType().GetCachedFields();

            for (int fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
            {
                FieldInfo field = fields[fieldIndex];

                if (Attribute.IsDefined(field, typeof(InjectAttribute)))
                {
                    InjectAttribute injectAttribute = field.GetCustomAttribute<InjectAttribute>();
                    field.SetValue(createdObject, container.Resolve<object>(field.FieldType, injectAttribute?.Id));
                }
            }
        }
    }
}
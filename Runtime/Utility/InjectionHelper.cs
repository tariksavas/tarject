using System;
using System.Collections.Generic;
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

                    object[] elementObjects = container.ResolveAll<object>(elementType, injectAttribute?.Id);
                    object[] arrayObjects = container.ResolveAll<object>(parameterType, injectAttribute?.Id);
                    
                    if (elementObjects == null && arrayObjects == null)
                    {
                        Debug.LogError($"Can not resolve depenceny! Type: {type} --- DependencyType: {parameterType}");
                        return false;
                    }
                    
                    List<object> combinedList = new List<object>();
                    
                    if (elementObjects is { Length: > 0 })
                    {
                        combinedList.AddRange(elementObjects);
                    }
                    
                    if (arrayObjects is { Length: > 0 })
                    {
                        for (int arrayObjectIndex = 0; arrayObjectIndex < arrayObjects.Length; arrayObjectIndex++)
                        {
                            if (arrayObjects[arrayObjectIndex] is not Array array)
                            {
                                continue;
                            }

                            for (int arrayIndex = 0; arrayIndex < array.Length; arrayIndex++)
                            {
                                combinedList.Add(array.GetValue(arrayIndex));
                            }
                        }
                    }
                    
                    Array parameterArray = Array.CreateInstance(elementType, combinedList.Count);
                    for (int index = 0; index < combinedList.Count; index++)
                    {
                        parameterArray.SetValue(combinedList[index], index);
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
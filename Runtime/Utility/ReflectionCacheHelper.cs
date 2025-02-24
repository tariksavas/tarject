using System;
using System.Collections.Generic;
using System.Reflection;
using Tarject.Runtime.Core.Injecter;

namespace Tarject.Runtime.Utility
{
    public static class ReflectionCacheHelper
    {
        private static Dictionary<object, Type> _typeCache = new Dictionary<object, Type>();

        private static Dictionary<Type, FieldInfo[]> _fieldInfoCache = new Dictionary<Type, FieldInfo[]>();

        private static Dictionary<Type, ConstructorInfo> _injectableConstructorInfoCache = new Dictionary<Type, ConstructorInfo>();

        private static Dictionary<ConstructorInfo, ParameterInfo[]> _parameterInfoCache = new Dictionary<ConstructorInfo, ParameterInfo[]>();

        public static Type GetCachedType(this object obj)
        {
            if (_typeCache.ContainsKey(obj))
            {
                return _typeCache[obj];
            }

            Type type = obj.GetType();
            _typeCache.Add(obj, type);

            return type;
        }

        public static FieldInfo[] GetCachedFields(this Type type)
        {
            if (_fieldInfoCache.ContainsKey(type))
            {
                return _fieldInfoCache[type];
            }

            FieldInfo[] baseTypeFields = type.BaseType != null
                ? GetCachedFields(type.BaseType)
                : Array.Empty<FieldInfo>();

            FieldInfo[] ownFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            FieldInfo[] allFields = new FieldInfo[baseTypeFields.Length + ownFields.Length];

            Array.Copy(baseTypeFields, 0, allFields, 0, baseTypeFields.Length);
            Array.Copy(ownFields, 0, allFields, baseTypeFields.Length, ownFields.Length);

            _fieldInfoCache.TryAdd(type, allFields);

            return allFields;
        }

        public static ConstructorInfo GetCachedInjectableConstructor(this Type type)
        {
            if (_injectableConstructorInfoCache.ContainsKey(type))
            {
                return _injectableConstructorInfoCache[type];
            }

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

                if (Attribute.IsDefined(constructorInfo, typeof(InjectAttribute)))
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

            _injectableConstructorInfoCache.Add(type, injectableConstructorInfo);

            return injectableConstructorInfo;
        }

        public static ParameterInfo[] GetCachedParameters(this ConstructorInfo constructorInfo)
        {
            if (_parameterInfoCache.ContainsKey(constructorInfo))
            {
                return _parameterInfoCache[constructorInfo];
            }

            ParameterInfo[] parameters = constructorInfo.GetParameters();
            _parameterInfoCache.Add(constructorInfo, parameters);

            return parameters;
        }
    }
}
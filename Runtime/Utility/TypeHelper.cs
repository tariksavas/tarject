using System;

namespace Tarject.Runtime.Utility
{
    public static class TypeHelper
    {
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
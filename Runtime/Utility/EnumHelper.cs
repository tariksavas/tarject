using System;

namespace Tarject.Runtime.Utility
{
    public static class EnumHelper
    {
        public static bool Has(this Enum @enum, object value)
        {
            return ((int)(object)@enum & (int)value) == (int)value;
        }

        public static T Add<T>(this Enum @enum, T value)
        {
            return (T)(object)((int)(object)@enum | (int)(object)value);
        }

        public static T Remove<T>(this Enum @enum, T value)
        {
            return (T)(object)((int)(object)@enum & ~(int)(object)value);
        }
    }
}

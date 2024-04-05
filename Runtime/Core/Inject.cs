using System;

namespace Tarject.Runtime.Core
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
    public class Inject : Attribute
    {
    }
}
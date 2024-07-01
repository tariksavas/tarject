using System;

namespace Tarject.Runtime.Core.Injecter
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Parameter, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
        public readonly string Id;

        public InjectAttribute()
        {
        }

        public InjectAttribute(string id)
        {
            Id = id;
        }
    }
}
using System;

namespace Tarject.Runtime.Core.Injecter
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Parameter, AllowMultiple = false)]
    public class Inject : Attribute
    {
        public readonly string Id;

        public Inject()
        {
        }

        public Inject(string id)
        {
            Id = id;
        }
    }
}
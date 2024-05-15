using System;
using UnityEngine;

namespace Tarject.Runtime.Core.Context
{
    [DefaultExecutionOrder(-100)]
    public abstract class TempContext : Context
    {
        public override T Resolve<T>(Type type = null, string id = "")
        {
            T t = Container.Resolve<T>(type, id);
            if (t != null)
            {
                return t;
            }

            return ProjectContext.Instance.Resolve<T>(type, id);
        }
    }
}

using System;
using UnityEngine;

namespace Tarject.Runtime.Core.Context
{
    [DefaultExecutionOrder(-100)]
    public class GameObjectContext : Context
    {
        public override T Resolve<T>(Type type = null, string id = "")
        {
            T t = Container.Resolve<T>(type, id);
            if (t != null)
            {
                return t;
            }

            return gameObject.scene.GetSceneContext().Resolve<T>(type, id);
        }
    }
}
using System;
using UnityEngine;

namespace Tarject.Runtime.Core.Context
{
    [DefaultExecutionOrder(-150)]
    public class SceneContext : Context
    {
        protected override void Awake()
        {
            this.AddSceneContextRegistry();

            base.Awake();
        }

        public override T Resolve<T>(Type type = null, string id = "")
        {
            T t = Container.Resolve<T>(type, id);
            if (t != null)
            {
                return t;
            }

            return ProjectContext.Instance.Resolve<T>(type, id);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            this.RemoveSceneContextRegistrty();
        }
    }
}
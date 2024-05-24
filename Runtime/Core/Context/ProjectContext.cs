using System;
using UnityEngine;

namespace Tarject.Runtime.Core.Context
{
    [DefaultExecutionOrder(-200)]
    public class ProjectContext : Context
    {
        public static ProjectContext Instance;

        protected override void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                if (Application.isPlaying)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            base.Awake();
        }

        public override T Resolve<T>(Type type = null, string id = "")
        {
            return Container.Resolve<T>(type, id);
        }
    }
}
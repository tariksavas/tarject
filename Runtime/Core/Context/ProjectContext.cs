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

        protected override void SetParentContainer()
        {
            Container.SetParentContainer(null);
        }
    }
}
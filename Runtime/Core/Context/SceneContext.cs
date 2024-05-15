using Tarject.Runtime.Utility;

namespace Tarject.Runtime.Core.Context
{
    public class SceneContext : TempContext
    {
        protected override void Awake()
        {
            this.AddSceneContextRegistrty();

            base.Awake();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            this.RemoveSceneContextRegistrty();
        }
    }
}

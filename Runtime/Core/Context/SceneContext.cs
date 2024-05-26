using UnityEngine;

namespace Tarject.Runtime.Core.Context
{
    [DefaultExecutionOrder(-150)]
    public class SceneContext : Context
    {
        protected override void Awake()
        {
            gameObject.scene.AddSceneContainerRegistry(Container);

            base.Awake();
        }

        protected override void SetParentContainer()
        {
            Container.SetParentContainer(ProjectContext.Instance.Container);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            gameObject.scene.RemoveSceneContainerRegistrty();
        }
    }
}
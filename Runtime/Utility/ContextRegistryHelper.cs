using Tarject.Runtime.Core.Context;
using UnityEngine.SceneManagement;

namespace Tarject.Runtime.Utility
{
    public static class ContextRegistryHelper
    {
        public static ContextRegistry GetContextRegistry()
        {
            return ProjectContext.Instance.Resolve<ContextRegistry>();
        }

        public static void AddSceneContextRegistrty(this SceneContext sceneContext)
        {
            ContextRegistry contextRegistry = GetContextRegistry();
            contextRegistry?.AddSceneContext(sceneContext);
        }

        public static void RemoveSceneContextRegistrty(this SceneContext sceneContext)
        {
            ContextRegistry contextRegistry = GetContextRegistry();
            contextRegistry?.RemoveSceneContext(sceneContext);
        }

        public static SceneContext GetSceneContext(this Scene scene)
        {
            ContextRegistry contextRegistry = GetContextRegistry();
            return contextRegistry?.GetSceneContext(scene);
        }
    }
}

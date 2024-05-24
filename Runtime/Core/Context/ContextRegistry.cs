using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Tarject.Runtime.Core.Context
{
    public static class ContextRegistry
    {
        private static readonly Dictionary<Scene, SceneContext> _sceneContextMap = new Dictionary<Scene, SceneContext>();

        private static readonly Dictionary<DIContainer, Context> _containerContextMap = new Dictionary<DIContainer, Context>();

        public static void AddSceneContextRegistry(this SceneContext sceneContext)
        {
            _sceneContextMap.Add(sceneContext.gameObject.scene, sceneContext);
        }

        public static void AddContainerContextRegistry(this DIContainer container, Context context)
        {
            _containerContextMap.Add(container, context);
        }

        public static void RemoveSceneContextRegistrty(this SceneContext sceneContext)
        {
            _sceneContextMap.Remove(sceneContext.gameObject.scene);
        }

        public static void RemoveContainerContextRegistry(this DIContainer container)
        {
            _containerContextMap.Remove(container);
        }

        public static SceneContext GetSceneContext(this Scene scene)
        {
            return _sceneContextMap[scene];
        }

        public static Context GetContainerContext(this DIContainer container)
        {
            return _containerContextMap[container];
        }
    }
}
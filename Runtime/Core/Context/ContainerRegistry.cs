using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Tarject.Runtime.Core.Context
{
    public static class ContainerRegistry
    {
        private static readonly Dictionary<Scene, DIContainer> _sceneContainerMap = new Dictionary<Scene, DIContainer>();

        public static void AddSceneContainerRegistry(this Scene scene, DIContainer container)
        {
            _sceneContainerMap.Add(scene, container);
        }

        public static void RemoveSceneContainerRegistrty(this Scene scene)
        {
            _sceneContainerMap.Remove(scene);
        }

        public static DIContainer GetSceneContainer(this Scene scene)
        {
            return _sceneContainerMap[scene];
        }
    }
}
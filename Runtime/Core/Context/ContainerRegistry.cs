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

        public static void RemoveSceneContainerRegistry(this Scene scene)
        {
            _sceneContainerMap.Remove(scene);
        }

        public static DIContainer GetSceneContainer(this Scene scene)
        {
            if (_sceneContainerMap.TryGetValue(scene, out DIContainer container))
            {
                return container;
            }

            return ProjectContext.Instance.Container;
        }
    }
}
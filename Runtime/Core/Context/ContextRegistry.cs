using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Tarject.Runtime.Core.Context
{
    public class ContextRegistry
    {
        private readonly Dictionary<Scene, SceneContext> _sceneContextMap;

        public ContextRegistry()
        {
            _sceneContextMap = new Dictionary<Scene, SceneContext>();
        }

        public void AddSceneContext(SceneContext sceneContext)
        {
            _sceneContextMap.Add(sceneContext.gameObject.scene, sceneContext);
        }

        public SceneContext GetSceneContext(Scene scene)
        {
            return _sceneContextMap[scene];
        }

        public void RemoveSceneContext(SceneContext sceneContext)
        {
            _sceneContextMap.Remove(sceneContext.gameObject.scene);
        }
    }
}

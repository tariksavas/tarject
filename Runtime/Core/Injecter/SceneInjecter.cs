using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Injecter
{
    public class SceneInjecter : MonoBehaviour
    {
        private void Awake()
        {
            //It is recommended to inherit each scene object to be injected from MonoInjecter for faster injecting.
            FindAndInjectSceneObjects();
        }

        private void FindAndInjectSceneObjects()
        {
            Context.SceneContext sceneContext = gameObject.scene.GetSceneContext();

            MonoBehaviour[] sceneObjects = FindObjectsOfType<MonoBehaviour>(true);
            for (int index = 0; index < sceneObjects.Length; index++)
            {
                sceneObjects[index].InjectToFields(sceneContext);
                sceneObjects[index].InjectToMethods(sceneContext);
            }
        }
    }
}

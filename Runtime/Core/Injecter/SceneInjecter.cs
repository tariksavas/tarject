using Tarject.Runtime.Core.Context;
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
            DIContainer container = gameObject.scene.GetSceneContainer();

            MonoBehaviour[] sceneObjects = FindObjectsOfType<MonoBehaviour>(true);
            for (int index = 0; index < sceneObjects.Length; index++)
            {
                sceneObjects[index].InjectToFields(container);
            }
        }
    }
}

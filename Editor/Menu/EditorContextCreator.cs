#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Injecter;

namespace Tarject.Editor.Menu
{
    public class EditorContextCreator : MonoBehaviour
    {
        [MenuItem("GameObject/Tarject/Project Context")]
        public static void CreateProjectContext()
        {
            GameObject go = new GameObject("ProjectContext");
            go.AddComponent<ProjectContext>();
        }

        [MenuItem("GameObject/Tarject/Scene Context")]
        public static void CreateSceneContext()
        {
            GameObject go = new GameObject("SceneContext");
            go.AddComponent<SceneContext>();
        }

        [MenuItem("GameObject/Tarject/GameObject Context")]
        public static void CreateGameObjectContext()
        {
            GameObject go = new GameObject("GameObjectContext");
            go.AddComponent<GameObjectContext>();
        }

        [MenuItem("GameObject/Tarject/Scene Injecter")]
        public static void CreateSceneInjecter()
        {
            GameObject go = new GameObject("SceneInjecter");
            go.AddComponent<SceneInjecter>();
        }
    }
}
#endif
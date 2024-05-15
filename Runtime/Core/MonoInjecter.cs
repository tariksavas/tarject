using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core
{
    public class MonoInjecter : MonoBehaviour
    {
        protected Context.Context TargetContext { private get; set; }

        protected virtual void Awake()
        {
            TargetContext ??= gameObject.scene.GetSceneContext();
            this.InjectToFields(TargetContext);
            this.InjectToMethods(TargetContext);
        }
    }
}
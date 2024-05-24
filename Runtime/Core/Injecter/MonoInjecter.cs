using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Injecter
{
    public class MonoInjecter : MonoBehaviour
    {
        public bool Injected { get; set; }

        protected Context.Context TargetContext { private get; set; }

        protected virtual void Awake()
        {
            if (Injected)
            {
                return;
            }

            TargetContext ??= gameObject.scene.GetSceneContext();
            this.InjectToFields(TargetContext);

            Injected = true;
        }
    }
}
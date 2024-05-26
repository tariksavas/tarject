using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core.Injecter
{
    public class MonoInjecter : MonoBehaviour
    {
        public bool Injected { get; set; }

        protected DIContainer TargetContainer { private get; set; }

        protected virtual void Awake()
        {
            if (Injected)
            {
                return;
            }

            TargetContainer ??= gameObject.scene.GetSceneContainer();
            this.InjectToFields(TargetContainer);

            Injected = true;
        }
    }
}
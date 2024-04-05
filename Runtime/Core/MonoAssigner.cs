using Tarject.Runtime.Utility;
using UnityEngine;

namespace Tarject.Runtime.Core
{
    public class MonoAssigner : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Assign();
        }

        private void Assign()
        {
            this.AssignInjectionToFields();
        }
    }
}
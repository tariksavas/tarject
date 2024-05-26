using UnityEngine;

namespace Tarject.Runtime.Core.Context
{
    [DefaultExecutionOrder(-100)]
    public class GameObjectContext : Context
    {
        protected override void SetParentContainer()
        {
            Container.SetParentContainer(gameObject.scene.GetSceneContainer());
        }
    }
}
using Tarject.Samples.Scripts.Runtime.InventoryModule.Controller;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Factory;
using Tarject.Runtime.Core.Installer;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.Installer
{
    public class InventoryInstaller : ObjectInstaller<InventoryInstaller>
    {
        public override void Install(DIContainer container)
        {
            container.Bind<InventoryData>().WithId("userInventory");
            container.Bind<InventoryController>();

            container.BindFactory<GameObjectFactory>();
        }
    }
}
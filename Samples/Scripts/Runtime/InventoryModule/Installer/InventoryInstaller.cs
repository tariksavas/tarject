using Runtime.InventoryModule.Controller;
using Runtime.InventoryModule.Model;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Factory;
using Tarject.Runtime.Core.Installer;

namespace Runtime.InventoryModule.Installer
{
    public class InventoryInstaller : ObjectInstaller<InventoryInstaller>
    {
        public override void Install(DIContainer container)
        {
            container.Bind<InventoryData>().WithId("inventory1");
            container.Bind<InventoryData>().WithId("inventory2");
            container.Bind<InventoryController>().WithTriggerableInterfaces();

            container.BindFactory<GameObjectFactory>();
        }
    }
}

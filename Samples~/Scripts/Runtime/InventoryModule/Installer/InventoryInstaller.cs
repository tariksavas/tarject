using Tarject.Samples.Scripts.Runtime.InventoryModule.Controller;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;
using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Config;
using Tarject.Samples.Scripts.Runtime.InventoryModule.View;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.Installer
{
    public class InventoryInstaller : ObjectInstaller<InventoryInstaller>
    {
        public override void Install(DIContainer container)
        {
            container.Bind<InventoryController>();

            container.BindFactory<InventoryUIItem.Factory>();

            container.BindFromInstance(PlayerConfigs.InventoryItems);
        }
    }
}
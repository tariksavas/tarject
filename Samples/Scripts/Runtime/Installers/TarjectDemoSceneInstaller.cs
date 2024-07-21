using Tarject.Samples.Scripts.Runtime.InventoryModule.Installer;
using Tarject.Samples.Scripts.Runtime.PlayerMovementModule.Installer;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;

namespace Tarject.Samples.Scripts.Runtime.Installers
{
    internal class TarjectDemoSceneInstaller : GameObjectInstaller
    {
        public override void Install(DIContainer container)
        {
            InventoryInstaller.CreateAndInstall(container);
            PlayerMovementInstaller.CreateAndInstall(container);
        }
    }
}
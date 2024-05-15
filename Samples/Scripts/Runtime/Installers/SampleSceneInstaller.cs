using Runtime.InventoryModule.Installer;
using Runtime.PlayerMovementModule.Installer;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;

namespace Runtime.Installers
{
    internal class SampleSceneInstaller : GameObjectInstaller
    {
        public override void Install(DIContainer container)
        {
            InventoryInstaller.CreateAndInstall(container);
            PlayerMovementInstaller.CreateAndInstall(container);
        }
    }
}

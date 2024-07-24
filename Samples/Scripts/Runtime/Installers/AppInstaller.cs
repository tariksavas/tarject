using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Installer;
using Tarject.Samples.Scripts.Runtime.UserModule.Installer;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;
using Tarject.Runtime.SignalBus.Controller;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Installer;

namespace Tarject.Samples.Scripts.Runtime.Installers
{
    public class AppInstaller : GameObjectInstaller
    {
        public override void Install(DIContainer container)
        {
            container.Bind<SignalController>();

            UserInstaller.CreateAndInstall(container);

            ConfigurationModuleInstaller.CreateAndInstall(container);

            GameSaveDataInstaller.CreateAndInstall(container);
        }
    }
}
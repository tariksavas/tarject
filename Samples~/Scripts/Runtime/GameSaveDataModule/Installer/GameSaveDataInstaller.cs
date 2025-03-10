using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Controller;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Installer
{
    public class GameSaveDataInstaller : ObjectInstaller<GameSaveDataInstaller>
    {
        public override void Install(DIContainer container)
        {
            container.Bind<LocalGameSaveDataService>().ToInterface<IGameSaveDataService>();
            container.Bind<RemoteGameSaveDataService>().ToInterface<IGameSaveDataService>();

            container.Bind<GameSaveDataController>();
        }
    }
}

using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.SignalBus.Controller;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service;
using Tarject.Samples.Scripts.Runtime.Signal;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Controller
{
    public class GameSaveDataController
    {
        private readonly IGameSaveDataService[] _gameSaveDataServices;

        private readonly SignalController _signalController;

        [Inject]
        public GameSaveDataController(IGameSaveDataService[] gameSaveDataServices, SignalController signalController)
        {
            _gameSaveDataServices = gameSaveDataServices;
            _signalController = signalController;
        }

        public void Save()
        {
            for (int index = 0; index < _gameSaveDataServices.Length; index++)
            {
                _gameSaveDataServices[index].Save();
            }

            _signalController.Fire(new GameDataSavedSignal(_gameSaveDataServices));
        }

        public void Load()
        {
            for (int index = 0; index < _gameSaveDataServices.Length; index++)
            {
                _gameSaveDataServices[index].Load();
            }

            _signalController.Fire(new GameDataLoadedSignal(_gameSaveDataServices));
        }
    }
}

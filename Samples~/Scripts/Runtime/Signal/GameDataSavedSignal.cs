using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service;

namespace Tarject.Samples.Scripts.Runtime.Signal
{
    public readonly struct GameDataSavedSignal
    {
        public readonly IGameSaveDataService[] GameSaveDataServices;

        public GameDataSavedSignal(IGameSaveDataService[] gameSaveDataServices)
        {
            GameSaveDataServices = gameSaveDataServices;
        }
    }
}

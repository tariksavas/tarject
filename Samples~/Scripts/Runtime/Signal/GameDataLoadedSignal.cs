using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service;

namespace Tarject.Samples.Scripts.Runtime.Signal
{
    public readonly struct GameDataLoadedSignal
    {
        public readonly IGameSaveDataService[] GameSaveDataServices;

        public GameDataLoadedSignal(IGameSaveDataService[] gameSaveDataServices)
        {
            GameSaveDataServices = gameSaveDataServices;
        }
    }
}

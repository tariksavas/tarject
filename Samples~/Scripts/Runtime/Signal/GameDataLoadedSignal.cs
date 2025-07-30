using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;

namespace Tarject.Samples.Scripts.Runtime.Signal
{
    public readonly struct GameDataLoadedSignal
    {
        public readonly PlayerSaveData PlayerSaveData;

        public GameDataLoadedSignal(PlayerSaveData playerSaveData)
        {
            PlayerSaveData = playerSaveData;
        }
    }
}

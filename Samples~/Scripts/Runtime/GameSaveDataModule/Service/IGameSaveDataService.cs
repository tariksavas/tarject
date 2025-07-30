using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service
{
    public interface IGameSaveDataService
    {
        bool Save();

        PlayerSaveData Load(string saveName);
        
        PlayerSaveData[] GetPlayerSaveDatas();
    }
}

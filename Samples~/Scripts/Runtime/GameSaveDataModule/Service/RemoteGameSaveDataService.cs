using System;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service
{
    public class RemoteGameSaveDataService : IGameSaveDataService
    {
        public bool Save()
        {
            return true;
        }
        
        public PlayerSaveData Load(string saveName)
        {
            return null;
        }

        public PlayerSaveData[] GetPlayerSaveDatas()
        {
            return Array.Empty<PlayerSaveData>();
        }
    }
}

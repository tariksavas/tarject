using UnityEngine;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service
{
    public class RemoteGameSaveDataService : IGameSaveDataService
    {
        public void Load()
        {
            Debug.Log($"[PROOF] - RemoteGameSaveDataService --> Called RemoteGameSaveDataService Load func");
        }

        public void Save()
        {
            Debug.Log($"[PROOF] - RemoteGameSaveDataService --> Called RemoteGameSaveDataService Save func");
        }
    }
}

using UnityEngine;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service
{
    public class LocalGameSaveDataService : IGameSaveDataService
    {
        public void Load()
        {
            Debug.Log($"[PROOF] - LocalGameSaveDataService --> Called LocalGameSaveData Load func");
        }

        public void Save()
        {
            Debug.Log($"[PROOF] - LocalGameSaveDataService --> Called LocalGameSaveData Save func");
        }
    }
}

using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Services;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service
{
    public class LocalGameSaveDataService : IGameSaveDataService
    {
        private readonly IConfigurationService _configurationService;

        private readonly PlayerSaveData[] _playerSaveDatas;
        
        public LocalGameSaveDataService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            
            _playerSaveDatas = _configurationService.GetPlayerSaveDatas();
        }

        public bool Save()
        {
            return true;
        }

        public PlayerSaveData Load(string saveName)
        {
            for (int index = 0; index < _playerSaveDatas.Length; index++)
            {
                if (_playerSaveDatas[index].Name == saveName)
                {
                    return _playerSaveDatas[index];
                }
            }

            return null;
        }

        public PlayerSaveData[] GetPlayerSaveDatas()
        {
            return _playerSaveDatas;
        }
    }
}
using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Config;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;

namespace Tarject.Samples.Scripts.Runtime.ConfigurationModule.Services
{
    public class StaticConfigurationService : IConfigurationService
    {
        public PlayerSaveData[] GetPlayerSaveDatas()
        {
            return PlayerConfigs.PlayerSaveDatas;
        }
    }
}
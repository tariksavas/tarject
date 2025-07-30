using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;

namespace Tarject.Samples.Scripts.Runtime.ConfigurationModule.Services
{
    public interface IConfigurationService
    {
        PlayerSaveData[] GetPlayerSaveDatas();
    }
}
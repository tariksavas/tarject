using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;

namespace Tarject.Samples.Scripts.Runtime.ConfigurationModule.Services
{
    public interface IConfigurationService
    {
        string GetUserIdConfiguration();

        string GetUserNameConfiguration();

        InventoryItem[] GetInventoryItemConfiguration();
    }
}
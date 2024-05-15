using Runtime.InventoryModule.Model;

namespace Runtime.ConfigurationModule.Services
{
    public interface IConfigurationService
    {
        string GetUserIdConfiguration();

        string GetUserNameConfiguration();

        InventoryItem[] GetInventoryItemConfiguration();
    }
}

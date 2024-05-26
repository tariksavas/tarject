using Runtime.InventoryModule.Model;
using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Config;
using UnityEngine;

namespace Runtime.ConfigurationModule.Services
{
    public class StaticConfigurationService : IConfigurationService
    {
        public string GetUserIdConfiguration()
        {
            return UserConfigs.USER_ID;
        }

        public string GetUserNameConfiguration()
        {
            return UserConfigs.USER_NAME;
        }

        public InventoryItem[] GetInventoryItemConfiguration()
        {
            return new InventoryItem[]
            {
                new InventoryItem(0, 1, "Sword", Color.blue),
                new InventoryItem(1, 1, "Armor", Color.green),
                new InventoryItem(2, 5, "Potion", Color.red)
            };
        }
    }
}
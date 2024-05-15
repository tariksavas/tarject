using Runtime.InventoryModule.Model;
using UnityEngine;

namespace Runtime.ConfigurationModule.Services
{
    public class StaticConfigurationService : IConfigurationService
    {
        public StaticConfigurationService()
        {
        }

        public string GetUserIdConfiguration()
        {
            return "26";
        }

        public string GetUserNameConfiguration()
        {
            return "tariksavas";
        }

        public InventoryItem[] GetInventoryItemConfiguration()
        {
            return new InventoryItem[]
            {
                new InventoryItem(0, 1, "Sword"), new InventoryItem(1, 1, "Armor"), new InventoryItem(2, 5,"Position")
            };
        }
    }
}

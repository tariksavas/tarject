using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;
using UnityEngine;

namespace Tarject.Samples.Scripts.Runtime.ConfigurationModule.Config
{
    public static class PlayerConfigs
    {
        public static readonly PlayerSaveData[] PlayerSaveDatas = new[]
        {
            new PlayerSaveData("1", "Player1", new UserItem[]
            {
                new UserItem(0, 2),
                new UserItem(1, 1),
                new UserItem(2, 5)
            }),
            new PlayerSaveData("2", "Player2", new UserItem[]
            {
                new UserItem(3, 4),
                new UserItem(4, 3),
                new UserItem(5, 7)
            })
        };
        
        public static readonly InventoryItem[] InventoryItems = new[]
        {
            new InventoryItem(0, "Sword", Color.blue),
            new InventoryItem(1, "Armor", Color.green),
            new InventoryItem(2, "Potion", Color.red),
            new InventoryItem(3, "Shield", Color.gray),
            new InventoryItem(4, "Helmet", Color.white),
            new InventoryItem(5, "Shoe", Color.yellow)
        };
    }
}
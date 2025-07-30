using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model
{
    public class PlayerSaveData
    {
        public readonly string Id;
        public readonly string Name;
        
        public readonly UserItem[] UserItems;
        
        public PlayerSaveData(string id, string name, UserItem[] userItems)
        {
            Id = id;
            Name = name;
            UserItems = userItems;
        }
    }
}
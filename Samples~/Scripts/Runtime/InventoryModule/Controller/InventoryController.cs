using System.Collections.Generic;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.Controller
{
    public class InventoryController
    {
        private readonly IReadOnlyDictionary<int, InventoryItem> _inventoryItemMap;

        public InventoryController(InventoryItem[] inventoryItems)
        {
            _inventoryItemMap = InitializeInventoryItemMap(inventoryItems);
        }

        private IReadOnlyDictionary<int, InventoryItem> InitializeInventoryItemMap(InventoryItem[] inventoryItems)
        {
            Dictionary<int, InventoryItem> inventoryItemMap = new Dictionary<int, InventoryItem>();

            foreach (var item in inventoryItems)
            {
                inventoryItemMap.TryAdd(item.Type, item);
            }

            return inventoryItemMap;
        }

        public InventoryItem GetInventoryItemByType(int type)
        {
            return _inventoryItemMap.GetValueOrDefault(type);
        }
    }
}
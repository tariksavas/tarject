using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.Controller
{
    public class InventoryController
    {
        private readonly InventoryItem[] _inventoryItems;

        public InventoryController(InventoryItem[] inventoryItems)
        {
            _inventoryItems = inventoryItems;
        }

        public InventoryItem[] GetUserInventoryItems()
        {
            return _inventoryItems;
        }
    }
}
using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;

namespace Tarject.Samples.Scripts.Runtime.Signal
{
    public readonly struct UserInventoryFetchedSignal
    {
        public readonly InventoryData InventoryData;

        public UserInventoryFetchedSignal(InventoryData inventoryData)
        {
            InventoryData = inventoryData;
        }
    }
}
using Runtime.InventoryModule.Model;

namespace Runtime.Signal
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
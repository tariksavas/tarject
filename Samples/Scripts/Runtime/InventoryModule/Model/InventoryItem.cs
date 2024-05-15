namespace Runtime.InventoryModule.Model
{
    public readonly struct InventoryItem
    {
        public readonly int Type;
        public readonly int Value;

        public readonly string ItemName;

        public InventoryItem(int type, int value, string itemName)
        {
            Type = type;
            Value = value;
            ItemName = itemName;
        }
    }
}

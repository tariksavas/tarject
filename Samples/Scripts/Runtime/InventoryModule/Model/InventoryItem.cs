using UnityEngine;

namespace Runtime.InventoryModule.Model
{
    public readonly struct InventoryItem
    {
        public readonly int Type;
        public readonly int Value;

        public readonly string ItemName;

        public readonly Color ItemColor;

        public InventoryItem(int type, int value, string itemName, Color itemColor)
        {
            Type = type;
            Value = value;
            ItemName = itemName;
            ItemColor = itemColor;
        }
    }
}
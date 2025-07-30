using UnityEngine;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.Model
{
    public class InventoryItem
    {
        public readonly int Type;

        public readonly string ItemName;

        public readonly Color ItemColor;

        public InventoryItem(int type, string itemName, Color itemColor)
        {
            Type = type;
            ItemName = itemName;
            ItemColor = itemColor;
        }
    }
}
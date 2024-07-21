using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;
using Tarject.Runtime.Core.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.UI
{
    public class InventoryUIItem : MonoBehaviour, IFactorable<InventoryItem>
    {
        [SerializeField]
        private Text _itemNameText;
        [SerializeField]
        private Text _itemCountText;

        [SerializeField]
        private Image _itemImage;

        public void InitializeFactory(InventoryItem inventoryItem)
        {
            InitializeItem(inventoryItem);
        }

        private void InitializeItem(InventoryItem inventoryItem)
        {
            _itemNameText.text = inventoryItem.ItemName;
            _itemCountText.text = inventoryItem.Value.ToString();

            _itemImage.color = inventoryItem.ItemColor;
        }
    }
}
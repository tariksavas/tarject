using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;
using Tarject.Runtime.Core.Factory;
using Tarject.Runtime.Core.Injecter;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.View
{
    public class InventoryUIItem : MonoBehaviour, IFactorable<UserItem>
    {
        [Inject]
        private readonly InventoryController _inventoryController;
        
        [SerializeField]
        private Text _itemNameText;
        [SerializeField]
        private Text _itemCountText;

        [SerializeField]
        private Image _itemImage;

        public void InitializeFactory(UserItem userItem)
        {
            InventoryItem inventoryItem = _inventoryController.GetInventoryItemByType(userItem.Type);
            
            InitializeView(inventoryItem.ItemName, userItem.Value, inventoryItem.ItemColor);
        }

        private void InitializeView(string itemName, int itemCount, Color itemColor)
        {
            _itemNameText.text = itemName;
            _itemCountText.text = itemCount.ToString();

            _itemImage.color = itemColor;
        }

        public class Factory : SeparatedGameObjectFactory<InventoryUIItem, UserItem>
        {

        }
    }
}
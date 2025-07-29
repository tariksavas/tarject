using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;
using Tarject.Runtime.Core.Injecter;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Controller;
using UnityEngine;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.View
{
    public class InventoryPanel : MonoInjecter
    {
        [Inject]
        private readonly InventoryController _inventoryController;
        
        [Inject]
        private readonly InventoryUIItem.Factory _inventoryUIItemFactory;

        [SerializeField]
        private Transform _content;
        
        [SerializeField]
        private InventoryUIItem _inventoryUIItemPrefab;

        protected override void Awake()
        {
            base.Awake();

            InitializePanel();
        }

        private void InitializePanel()
        {
            InventoryItem[] inventoryItems = _inventoryController.GetUserInventoryItems();
            
            if (inventoryItems == null || inventoryItems.Length == 0)
            {
                return;
            }

            for (int index = 0; index < inventoryItems.Length; index++)
            {
                _inventoryUIItemFactory.Create(_inventoryUIItemPrefab, _content, inventoryItems[index]);
            }
        }
    }
}

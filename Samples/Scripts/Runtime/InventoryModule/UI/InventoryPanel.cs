using Runtime.InventoryModule.Model;
using Runtime.Signal;
using Tarject.Runtime.Core;
using Tarject.Runtime.SignalBus.Controller;
using UnityEngine;

namespace Runtime.InventoryModule.UI
{
    public class InventoryPanel : MonoInjecter
    {
        [Inject("inventory1")]
        private readonly InventoryData _inventoryData1;
        
        [Inject("inventory2")]
        private readonly InventoryData _inventoryData2;
        
        [Inject]
        private readonly SignalController _signalController;

        protected override void Awake()
        {
            base.Awake();

            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _signalController.Subscribe<UserInventoryFetchedSignal>(OnUserInventoryFetched);
        }

        private void OnUserInventoryFetched(UserInventoryFetchedSignal _)
        {
            //Send param id for debug
            InitializePanel(_inventoryData1, "inventory1");

            InitializePanel(_inventoryData2, "inventory2");
        }

        private void InitializePanel(InventoryData inventoryData, string id)
        {
            if (inventoryData.items == null || inventoryData.items.Count == 0)
            {
                Debug.LogWarning($"InventoryPanel --> InventoryData items empty! Id: {id}");
                return;
            }

            for (int index = 0; index < inventoryData.items.Count; index++)
            {
                InventoryItem item = inventoryData.items[index];

                Debug.Log($"InventoryPanel --> {index + 1}.=> type: {item.Type} - value: {item.Value} - name: {item.ItemName}");
            }
        }

        private void UnsubscribeEvents()
        {
            _signalController.Unsubscribe<UserInventoryFetchedSignal>(OnUserInventoryFetched);
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }
    }
}

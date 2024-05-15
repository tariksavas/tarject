using Runtime.InventoryModule.Model;
using Runtime.Signal;
using Tarject.Runtime.Core;
using Tarject.Runtime.SignalBus.Controller;
using UnityEngine;

namespace Runtime.InventoryModule.UI
{
    public class InventoryUIItem : MonoInjecter
    {
        private InventoryData _inventoryData;
        
        private SignalController _signalController;

        [Inject]
        public void Inject([Inject("inventory1")] InventoryData inventoryData, SignalController signalController)
        {
            _inventoryData = inventoryData;
            _signalController = signalController;
        }

        protected override void Awake()
        {
            base.Awake();

            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _signalController.Subscribe<UserInventoryFetchedSignal>(OnUserInventoryFetched);
        }

        private void OnUserInventoryFetched(UserInventoryFetchedSignal signal)
        {
            InitializeItem(_inventoryData);
        }

        private void InitializeItem(InventoryData inventoryData)
        {
            if (inventoryData.items == null || inventoryData.items.Count == 0)
            {
                Debug.LogError($"InventoryData items null or empty!");
                return;
            }

            InventoryItem item = inventoryData.items[0];

            Debug.Log($"InventoryUIItem --> type: {item.Type} - value: {item.Value} - name: {item.ItemName}");
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

using Runtime.InventoryModule.Model;
using Runtime.Signal;
using Tarject.Runtime.Core.Factory;
using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.SignalBus.Controller;
using UnityEngine;

namespace Runtime.InventoryModule.UI
{
    public class InventoryPanel : MonoInjecter
    {
        [Inject("userInventory")]
        private readonly InventoryData _inventoryData;
        
        [Inject]
        private readonly SignalController _signalController;
        
        [Inject]
        private readonly GameObjectFactory _gameObjectFactory;

        [SerializeField]
        private Transform _content;
        
        [SerializeField]
        private InventoryUIItem _inventoryUIItemPrefab;

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
            InitializePanel(_inventoryData);
        }

        private void InitializePanel(InventoryData inventoryData)
        {
            if (inventoryData.items == null || inventoryData.items.Count == 0)
            {
                return;
            }

            for (int index = 0; index < inventoryData.items.Count; index++)
            {
                _gameObjectFactory.Create(_inventoryUIItemPrefab, _content, inventoryData.items[index]);
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

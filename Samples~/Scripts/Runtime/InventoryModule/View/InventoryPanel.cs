using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.SignalBus.Controller;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Controller;
using Tarject.Samples.Scripts.Runtime.Signal;
using UnityEngine;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.View
{
    public class InventoryPanel : MonoInjecter
    {
        [Inject]
        private readonly InventoryController _inventoryController;
        
        [Inject]
        private readonly InventoryUIItem.Factory _inventoryUIItemFactory;

        [Inject]
        private readonly SignalController _signalController;
        
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
            _signalController.Subscribe<GameDataLoadedSignal>(OnGameDataLoaded);
        }

        private void OnGameDataLoaded(GameDataLoadedSignal signal)
        {
            for (int index = _content.childCount - 1; index >= 0; index--)
            {
                Destroy(_content.GetChild(index).gameObject);
            }
            
            InitializeView(signal.PlayerSaveData);
        }

        private void InitializeView(PlayerSaveData playerSaveData)
        {
            if (playerSaveData.UserItems == null || playerSaveData.UserItems.Length == 0)
            {
                return;
            }

            for (int index = 0; index < playerSaveData.UserItems.Length; index++)
            {
                _inventoryUIItemFactory.Create(_inventoryUIItemPrefab, _content, playerSaveData.UserItems[index]);
            }
        }

        private void UnsubscribeEvents()
        {
            _signalController.Unsubscribe<GameDataLoadedSignal>(OnGameDataLoaded);
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }
    }
}

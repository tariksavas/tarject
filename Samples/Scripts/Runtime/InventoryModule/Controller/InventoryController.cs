using Runtime.ConfigurationModule.Services;
using Runtime.InventoryModule.Model;
using Runtime.Signal;
using Runtime.UserModule.Model;
using System;
using Tarject.Runtime.Core;
using Tarject.Runtime.Core.Interfaces;
using Tarject.Runtime.SignalBus.Controller;
using Tarject.Runtime.StructuralDefinitions;
using UnityEngine;
using IDisposable = Tarject.Runtime.Core.Interfaces.IDisposable;

namespace Runtime.InventoryModule.Controller
{
    public class InventoryController : IInitializable, IDisposable
    {
        private readonly SignalController _signalController;

        private readonly UserData _userData;

        private readonly InventoryData _inventoryData1;
        private readonly InventoryData _inventoryData2;

        private readonly IConfigurationService _configurationService;

        public InventoryController(SignalController signalController, UserData userData, [Inject("inventory1")] InventoryData inventoryData1,
            [Inject("inventory2")] InventoryData inventoryData2, IConfigurationService configurationService)
        {
            _signalController = signalController;
            _userData = userData;
            _inventoryData1 = inventoryData1;
            _inventoryData2 = inventoryData2;
            _configurationService = configurationService;
        }

        public void Initialize()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _signalController.Subscribe<UserDataReceivedSignal>(OnUserDataReceived);
        }

        private void OnUserDataReceived(UserDataReceivedSignal _)
        {
            InitializeUserInventory();
        }

        private void InitializeUserInventory()
        {
            InventoryItem[] inventoryData = GetUserInventory(_userData.userId);

            _inventoryData1.items = new OptimizedList<InventoryItem>(inventoryData);
            _inventoryData2.items = new OptimizedList<InventoryItem>();

            Debug.LogWarning($"InventoryController --> InventoryData with Id: [inventory1] must be contain data but Id: [inventory2] must be empty!");

            _signalController.Fire(new UserInventoryFetchedSignal());
        }

        private InventoryItem[] GetUserInventory(string userId)
        {
            if (userId != _configurationService.GetUserIdConfiguration())
            {
                return Array.Empty<InventoryItem>();
            }

            return _configurationService.GetInventoryItemConfiguration();
        }

        private void UnsubscribeEvents()
        {
            _signalController.Unsubscribe<UserDataReceivedSignal>(OnUserDataReceived);
        }

        public void Dispose()
        {
            UnsubscribeEvents();
        }
    }
}

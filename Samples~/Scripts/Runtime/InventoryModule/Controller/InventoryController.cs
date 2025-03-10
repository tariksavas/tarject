﻿using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Services;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;
using Tarject.Samples.Scripts.Runtime.Signal;
using System;
using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Core.Interfaces;
using Tarject.Runtime.SignalBus.Controller;
using Tarject.Runtime.StructuralDefinitions;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.Controller
{
    public class InventoryController : IInitializable, ILateDisposable
    {
        private readonly SignalController _signalController;

        private readonly InventoryData _inventoryData;

        private readonly IConfigurationService _configurationService;

        public InventoryController(SignalController signalController, [Inject("userInventory")] InventoryData inventoryData, IConfigurationService configurationService)
        {
            _signalController = signalController;
            _inventoryData = inventoryData;
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

        private void OnUserDataReceived(UserDataReceivedSignal signal)
        {
            InitializeUserInventory(signal.UserId);
        }

        private void InitializeUserInventory(string userId)
        {
            InventoryItem[] inventoryData = GetUserInventory(userId);

            _inventoryData.items = new OptimizedList<InventoryItem>(inventoryData);

            _signalController.Fire(new UserInventoryFetchedSignal(_inventoryData));
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

        public void LateDispose()
        {
            UnsubscribeEvents();
        }
    }
}
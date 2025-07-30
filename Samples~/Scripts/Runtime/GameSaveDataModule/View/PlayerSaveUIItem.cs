using Tarject.Runtime.Core.Factory;
using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.SignalBus.Controller;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;
using Tarject.Samples.Scripts.Runtime.Signal;
using UnityEngine;
using UnityEngine.UI;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.View
{
    public class PlayerSaveUIItem : MonoBehaviour, IFactorable<PlayerSaveData>
    {
        [Inject]
        private readonly SignalController _signalController;
        
        [SerializeField]
        private Text _playerNameText;
        
        [SerializeField]
        private Button _button;

        private PlayerSaveData _playerSaveData;
        
        private void Awake()
        {
            SubscribeEvents();
        }

        public void InitializeFactory(PlayerSaveData data)
        {
            _playerNameText.text = data.Name;
            _playerSaveData = data;
        }

        private void SubscribeEvents()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _signalController.Fire(new GameDataLoadedSignal(_playerSaveData));
        }

        private void UnsubscribeEvents()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }
    }
}
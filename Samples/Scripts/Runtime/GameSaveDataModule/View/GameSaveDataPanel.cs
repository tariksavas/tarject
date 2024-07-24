using Tarject.Runtime.Core.Injecter;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.View
{
    public class GameSaveDataPanel : MonoInjecter
    {
        [Inject]
        private readonly GameSaveDataController _gameSaveDataController;

        [SerializeField]
        private Button _saveButton;
        [SerializeField]
        private Button _loadButton;

        protected override void Awake()
        {
            base.Awake();

            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _saveButton.onClick.AddListener(OnSaveButtonClicked);
            _loadButton.onClick.AddListener(OnLoadButtonClicked);
        }

        private void OnSaveButtonClicked()
        {
            _gameSaveDataController.Save();
        }

        private void OnLoadButtonClicked()
        {
            _gameSaveDataController.Load();
        }

        private void UnsubscribeEvents()
        {
            _saveButton.onClick.RemoveListener(OnSaveButtonClicked);
            _loadButton.onClick.RemoveListener(OnLoadButtonClicked);
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }
    }
}
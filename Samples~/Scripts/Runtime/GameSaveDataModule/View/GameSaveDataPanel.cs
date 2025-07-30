using Tarject.Runtime.Core.Injecter;
using Tarject.Runtime.Core.Instantiator;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service;
using UnityEngine;

namespace Tarject.Samples.Scripts.Runtime.GameSaveDataModule.View
{
    public class GameSaveDataPanel : MonoInjecter
    {
        [Inject]
        private readonly IInstantiator _instantiator;
        
        [Inject]
        private readonly IGameSaveDataService _gameSaveDataService;
        
        [SerializeField]
        private Transform _content;

        [SerializeField]
        private PlayerSaveUIItem _playerSaveUIItemPrefab;

        protected override void Awake()
        {
            base.Awake();

            InitializeView();
        }

        private void InitializeView()
        {
            PlayerSaveData[] datas = _gameSaveDataService.GetPlayerSaveDatas();
            for (int index = 0; index < datas.Length; index++)
            {
                _instantiator.Create(_playerSaveUIItemPrefab, datas[index], _content);
            }
        }
    }
}
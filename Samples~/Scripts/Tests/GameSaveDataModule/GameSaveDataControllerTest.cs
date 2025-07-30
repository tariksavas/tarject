using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Services;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Model;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service;

namespace Tarject.Samples.Scripts.Tests.GameSaveDataModule
{
    internal class GameSaveDataControllerTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<StaticConfigurationService>().ToInterface<IConfigurationService>();
            Container.Bind<LocalGameSaveDataService>().ToInterface<IGameSaveDataService>();
        }

        [Test]
        public void SaveData()
        {
            IGameSaveDataService gameSaveDataService = Container.Resolve<IGameSaveDataService>();

            Assert.IsNotNull(gameSaveDataService);

            bool? saved = gameSaveDataService?.Save();
            Assert.IsTrue(saved);
        }

        [Test]
        public void LoadData()
        {
            IGameSaveDataService gameSaveDataService = Container.Resolve<IGameSaveDataService>();
            IConfigurationService configurationService = Container.Resolve<IConfigurationService>();

            PlayerSaveData[] playerSaveDatas = configurationService.GetPlayerSaveDatas();
            Assert.IsTrue(playerSaveDatas.Length > 0);

            PlayerSaveData loadedPlayerSaveDatas = gameSaveDataService?.Load(playerSaveDatas[0].Name);
            Assert.IsNotNull(loadedPlayerSaveDatas);
        }

        [Test]
        public void GetPlayerSaveDatas()
        {
            IGameSaveDataService gameSaveDataService = Container.Resolve<IGameSaveDataService>();
        
            Assert.IsNotNull(gameSaveDataService);
        
            PlayerSaveData[] playerSaveDatas = gameSaveDataService?.GetPlayerSaveDatas();
            Assert.IsNotNull(playerSaveDatas);
            Assert.IsTrue(playerSaveDatas.Length > 0);
        }
    }
}

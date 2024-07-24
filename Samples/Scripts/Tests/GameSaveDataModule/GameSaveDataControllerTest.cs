using NUnit.Framework;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Runtime.SignalBus.Controller;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Controller;
using Tarject.Samples.Scripts.Runtime.GameSaveDataModule.Service;
using Tarject.Samples.Scripts.Runtime.Signal;

namespace Tarject.Samples.Scripts.Tests.GameSaveDataModule
{
    internal class GameSaveDataControllerTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<SignalController>();
            Container.Bind<LocalGameSaveDataService>().ToInterface<IGameSaveDataService>();
            Container.Bind<RemoteGameSaveDataService>().ToInterface<IGameSaveDataService>();
            Container.Bind<GameSaveDataController>();
        }

        [Test]
        public void SaveData()
        {
            SignalController signalController = Container.Resolve<SignalController>();
            GameSaveDataController gameSaveDataController = Container.Resolve<GameSaveDataController>();

            signalController.Subscribe<GameDataSavedSignal>(Action);

            gameSaveDataController.Save();
            void Action(GameDataSavedSignal signal)
            {
                Assert.IsNotNull(signal);
                Assert.IsTrue(signal.GameSaveDataServices.Length > 0);
            }

            Assert.IsNotNull(gameSaveDataController);
        }

        [Test]
        public void LoadData()
        {
            SignalController signalController = Container.Resolve<SignalController>();
            GameSaveDataController gameSaveDataController = Container.Resolve<GameSaveDataController>();

            signalController.Subscribe<GameDataLoadedSignal>(Action);

            gameSaveDataController.Load();
            void Action(GameDataLoadedSignal signal)
            {
                Assert.IsNotNull(signal);
                Assert.IsTrue(signal.GameSaveDataServices.Length > 0);
            }

            Assert.IsNotNull(gameSaveDataController);
        }
    }
}

using NUnit.Framework;
using Runtime.ConfigurationModule.Services;
using Runtime.InventoryModule.Controller;
using Runtime.InventoryModule.Model;
using Runtime.Signal;
using Tarject.Runtime.SignalBus.Controller;
using Tarject.Editor.TestFramework.UnitTest;

namespace Tarject.Samples.Scripts.Tests.InventoryModule
{
    [TestFixture]
    public class InventoryControllerTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<InventoryController>();
            Container.Bind<SignalController>(); 
            Container.Bind<InventoryData>().WithId("userInventory");
            Container.Bind<StaticConfigurationService>().ToInterface<IConfigurationService>();
        }

        [Test]
        public void Fetch_User_Inventory()
        {
            InventoryController inventoryController = Container.Resolve<InventoryController>();
            SignalController signalController = Container.Resolve<SignalController>();
            IConfigurationService configurationService = Container.Resolve<IConfigurationService>();

            string mockedUserId = configurationService.GetUserIdConfiguration();

            inventoryController.Initialize();
            
            signalController.Subscribe<UserInventoryFetchedSignal>(Action);

            signalController.Fire(new UserDataReceivedSignal(mockedUserId));

            void Action(UserInventoryFetchedSignal signal)
            {
                Assert.IsNotNull(signal.InventoryData);
                Assert.IsTrue(signal.InventoryData.items.Count > 0);
            }

            Assert.IsNotNull(inventoryController);
        }
    }
}
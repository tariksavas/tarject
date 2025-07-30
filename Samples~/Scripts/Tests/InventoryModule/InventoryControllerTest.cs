using NUnit.Framework;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Controller;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;
using Tarject.Editor.TestFramework.UnitTest;
using Tarject.Samples.Scripts.Runtime.ConfigurationModule.Config;

namespace Tarject.Samples.Scripts.Tests.InventoryModule
{
    public class InventoryControllerTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<InventoryController>();
            
            Container.BindFromInstance(PlayerConfigs.InventoryItems);
        }
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Get_Inventory_Item(int itemType)
        {
            InventoryController inventoryController = Container.Resolve<InventoryController>();
            
            InventoryItem inventoryItem = inventoryController.GetInventoryItemByType(itemType);
            
            Assert.IsNotNull(inventoryItem);
        }
    }
}
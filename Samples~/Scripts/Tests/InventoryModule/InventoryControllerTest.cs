using NUnit.Framework;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Controller;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;
using Tarject.Editor.TestFramework.UnitTest;
using UnityEngine;

namespace Tarject.Samples.Scripts.Tests.InventoryModule
{
    public class InventoryControllerTest : TarjectUnitTestFixture
    {
        protected override void Setup()
        {
            Container.Bind<InventoryController>();
            
            InventoryItem[] inventoryItems =  new InventoryItem[]
            {
                new InventoryItem(0, 2, "Sword", Color.blue),
                new InventoryItem(1, 1, "Armor", Color.green),
                new InventoryItem(2, 5, "Potion", Color.red)
            };
            
            Container.BindFromInstance(inventoryItems);
        }
        
        [Test]
        public void Fetch_User_Inventory()
        {
            InventoryController inventoryController = Container.Resolve<InventoryController>();
            
            InventoryItem[] inventoryItems = inventoryController.GetUserInventoryItems();
            
            Assert.IsNotNull(inventoryController);
            Assert.IsNotNull(inventoryItems);
            Assert.IsTrue(inventoryItems.Length == 3);
        }
    }
}
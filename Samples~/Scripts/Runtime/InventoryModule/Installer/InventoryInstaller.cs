using UnityEngine;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Controller;
using Tarject.Samples.Scripts.Runtime.InventoryModule.Model;
using Tarject.Runtime.Core.Context;
using Tarject.Runtime.Core.Installer;
using Tarject.Samples.Scripts.Runtime.InventoryModule.View;

namespace Tarject.Samples.Scripts.Runtime.InventoryModule.Installer
{
    public class InventoryInstaller : ObjectInstaller<InventoryInstaller>
    {
        public override void Install(DIContainer container)
        {
            container.Bind<InventoryController>();

            container.BindFactory<InventoryUIItem.Factory>();

            BindInventoryItems(container);
            BindEachInventoryItems(container);
        }

        private void BindInventoryItems(DIContainer container)
        {
            InventoryItem[] inventoryItems =  new InventoryItem[]
            {
                new InventoryItem(0, 2, "Sword", Color.blue),
                new InventoryItem(1, 1, "Armor", Color.green),
                new InventoryItem(2, 5, "Potion", Color.red)
            };
            
            container.BindFromInstance(inventoryItems);
        }

        private void BindEachInventoryItems(DIContainer container)
        {
            InventoryItem[] inventoryItems =  new InventoryItem[]
            {
                new InventoryItem(3, 4, "Shield", Color.gray),
                new InventoryItem(4, 3, "Helmet", Color.white),
                new InventoryItem(5, 7, "Shoe", Color.yellow)
            };

            for (int index = 0; index < inventoryItems.Length; index++)
            {
                container.BindFromInstance(inventoryItems[index]);
            }
        }
    }
}
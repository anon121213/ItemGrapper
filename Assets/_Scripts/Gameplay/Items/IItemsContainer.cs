using System;
using _Scripts.Gameplay.Grapper;

namespace _Scripts.Gameplay.Items
{
    public interface IItemsContainer : IItemsContainerDelivered
    {
        event Action DeliveryItem;
        event Action AllItemsDelivered;
        public void AddItem(Item item);
    }
    
    public interface IItemsContainerDelivered
    {
        public void TryAddDeliveredItem(Item item);
    }
}
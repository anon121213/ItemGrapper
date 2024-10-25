using System.Collections.Generic;
using _Scripts.Gameplay.Grapper;

namespace _Scripts.Gameplay.Items
{
    public class ItemsContainer : IItemsContainer
    {
        private readonly List<Item> _items = new ();
        private readonly List<Item> _deliveredItems = new ();
        
        public void AddItem(Item item) => 
            _items.Add(item);

        public void TryAddDeliveredItem(Item item)
        {
            if (!_items.Contains(item))
                return;
            
            if (item.IsGraped)
                return;

            if (!item.IsDelivered)
                return;
            
            _deliveredItems.Add(item);
        }

        public bool CheckDeliveredItems() => 
            _items.Count == _deliveredItems.Count;
    }
}
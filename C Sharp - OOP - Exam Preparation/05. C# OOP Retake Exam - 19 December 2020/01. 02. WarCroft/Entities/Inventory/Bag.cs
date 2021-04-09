using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private ICollection<Item> items;
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;
        public int Load => this.Items.Sum(i=>i.Weight);
        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection < Item > )this.items;
        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.EmptyBag);
            }

            Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);

            return item;
        }
    }
}

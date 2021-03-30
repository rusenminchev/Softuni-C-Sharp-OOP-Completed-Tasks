using System;
using System.Text;
using System.Collections.Generic;

using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Food
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}

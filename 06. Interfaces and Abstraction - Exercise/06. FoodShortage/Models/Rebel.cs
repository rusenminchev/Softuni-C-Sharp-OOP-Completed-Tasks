using FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoodShortage.Models
{
    public class Rebel : Person
    {
        private const int VALID_BOUGHT_FOOD = 5;

        public Rebel(string name, int age, string group)
            :base(name, age)
        {
            this.Group = group;
        }
        public string Group { get; private set; }

        public override int BuyFood()
        {
            return VALID_BOUGHT_FOOD;
        }
    }
}

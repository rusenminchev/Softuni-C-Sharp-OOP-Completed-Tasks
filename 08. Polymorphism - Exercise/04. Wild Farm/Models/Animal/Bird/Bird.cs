using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Bird
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; set; }

        public abstract override string ProduceSound();

        public override string ToString()
        {
            return base.ToString() + $" {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Mammal
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
        public abstract override string ProduceSound();

        public override string ToString()
        {
            return base.ToString() + $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}

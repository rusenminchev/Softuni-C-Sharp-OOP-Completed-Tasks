using System;
using System.Collections.Generic;
using System.Text;

using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animal.Mammal.Feline
{
    public class Cat : Feline
    {
        private const double WEIGHT_INCREMENT = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override List<Type> PreferredFood => new List<Type>() {typeof(Meat), typeof(Vegetable) };

        public override double WeightIncrement => WEIGHT_INCREMENT;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}

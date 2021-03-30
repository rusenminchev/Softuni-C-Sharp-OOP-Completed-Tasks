using System;
using System.Text;
using System.Collections.Generic;

using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animal.Mammal
{
    public class Mouse : Mammal
    {
        private const double WEIGHT_INCREMENT = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override List<Type> PreferredFood => new List<Type>() { typeof(Fruit), typeof(Vegetable) };

        public override double WeightIncrement => WEIGHT_INCREMENT;

        public override string ProduceSound()
        {
           return "Squeak";
        }
    }
}

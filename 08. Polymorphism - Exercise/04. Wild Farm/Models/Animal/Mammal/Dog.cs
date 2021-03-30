using System;
using System.Text;
using System.Collections.Generic;

using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animal.Mammal
{
    public class Dog : Mammal
    {
        private const double WEIGHT_INCREMENT = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override List<Type> PreferredFood => new List<Type>() {typeof(Meat) };

        public override double WeightIncrement => WEIGHT_INCREMENT;
        public override string ProduceSound()
        {
            return "Woof!";
        }
       
    }
}

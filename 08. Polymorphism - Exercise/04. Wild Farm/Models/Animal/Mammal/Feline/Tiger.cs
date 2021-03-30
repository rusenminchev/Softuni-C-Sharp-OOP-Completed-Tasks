using System;
using System.Text;
using System.Collections.Generic;

using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animal.Mammal.Feline
{
    public class Tiger : Feline
    {
        private const double WEIGHT_INCREMENT = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override List<Type> PreferredFood => new List<Type>() {typeof(Meat) };

        public override double WeightIncrement => WEIGHT_INCREMENT;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}

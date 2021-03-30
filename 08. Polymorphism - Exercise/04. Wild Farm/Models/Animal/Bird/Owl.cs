using System;
using System.Collections.Generic;
using System.Text;

using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animal.Bird
{
    public class Owl : Bird
    {
        private const double WEIGHT_INCREMENT = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override List<Type> PreferredFood => new List<Type>() { typeof(Meat) };

        public override double WeightIncrement => WEIGHT_INCREMENT;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}

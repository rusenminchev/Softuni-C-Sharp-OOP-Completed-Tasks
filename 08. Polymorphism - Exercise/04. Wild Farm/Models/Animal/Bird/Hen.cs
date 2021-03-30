using System;
using System.Collections.Generic;
using System.Text;

using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animal.Bird
{
    public class Hen : Bird
    {
        private const double WEIGHT_INCREMENT = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override List<Type> PreferredFood => new List<Type>() { typeof(Vegetable)
            , typeof(Fruit), typeof(Meat), typeof(Seeds)};

        public override double WeightIncrement => WEIGHT_INCREMENT;

        public override string ProduceSound()
        {
           return "Cluck";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        abstract string ProduceSound();
        void Eat(IFood food);
    }
}

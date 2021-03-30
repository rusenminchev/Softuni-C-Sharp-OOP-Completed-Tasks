using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using WildFarm.Models.Food;
using WildFarm.Models.Contracts;
using WildFarm.Models.Food.Contracts;
using WildFarm.Exceptions;

namespace WildFarm.Models.Animal
{
    public abstract class Animal : IAnimal
    {
        public static string INVALID_FOOD_TYPE_EXCEPTION_MESSAGE = "{0} does not eat {1}!";

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public abstract List<Type> PreferredFood { get; }
        public abstract double WeightIncrement { get; }

        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!this.PreferredFood.Contains(food.GetType()))
            {
                throw new InvalidFoodTypeException(String.Format
                    (INVALID_FOOD_TYPE_EXCEPTION_MESSAGE, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightIncrement;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}

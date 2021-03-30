using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Factories
{
    public class FoodFactory
    {

        public Food ProduceFood(string foodType, int quantity)
        {
            Food food = null;

            if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}

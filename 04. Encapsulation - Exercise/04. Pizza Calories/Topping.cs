using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double TOPPING_MINIMUM_VALID_WEIGHT = 0;
        private const double TOPPING_MAXIMUM_VALID_WEIGHT = 50;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "meat" && valueToLower != "veggies" && valueToLower != "cheese" && valueToLower != "sauce")
                {
                    throw new ArgumentException(string.Format(GlobalConstants
                        .GlobalConstants.InvalidToppingTypeExceptionMessage, value));
                }

                this.type = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= TOPPING_MINIMUM_VALID_WEIGHT || value > TOPPING_MAXIMUM_VALID_WEIGHT)
                {
                    throw new ArgumentException(string.Format(GlobalConstants
                        .GlobalConstants.InvalidToppingWeightExceptionMessage, this.Type));
                }

                this.weight = value;
            }
        }

        public double Calories => CalculateCalories();


        private double CalculateCalories()
        {
            double calories = this.Weight * 2;

            switch (this.Type.ToLower())
            {
                case "meat":
                    calories *= 1.2;
                    break;
                case "veggies":
                    calories *= 0.8;
                    break;
                case "cheese":
                    calories *= 1.1;
                    break;
                case "sauce":
                    calories *= 0.9;
                    break;
            }

            return calories;
        }
    }
}

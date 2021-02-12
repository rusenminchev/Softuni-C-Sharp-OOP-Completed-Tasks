using PizzaCalories.GlobalConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double DOUGH_MINIMUM_VALID_WEIGHT = 0;
        private const double DOUGH_MAXIMUM_VALID_WEIGHT = 200;

        private string type;
        private string bakingTechnique;
        private double weight;

        public Dough(string type, string bakingTechnique, double weight)
        {
            this.Type = type;
            this.BakingTechnique = bakingTechnique;
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
                if (string.IsNullOrEmpty(valueToLower) && valueToLower != "white" && valueToLower != "wholegrain")
                {
                    throw new ArgumentException(GlobalConstants.GlobalConstants.InvalidDoughTypeExceptionMessage);
                }

                this.type = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                string valueToLower = value.ToLower();
                if (string.IsNullOrEmpty(valueToLower) && valueToLower != "crispy" && valueToLower != "chewy" && valueToLower != "homemade")
                {
                    throw new ArgumentException(GlobalConstants.GlobalConstants.InvalidDoughTypeExceptionMessage);
                }

                this.bakingTechnique = value;
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

                if (value <= DOUGH_MINIMUM_VALID_WEIGHT || value > DOUGH_MAXIMUM_VALID_WEIGHT)
                {
                    throw new ArgumentException(GlobalConstants.GlobalConstants.InvalidDoughWeightExceptionMessage);
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
                case "white":
                    calories *= 1.5;
                    break;
                case "wholegrain":
                    calories *= 1.0;
                    break;

            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    calories *= 0.9;
                    break;
                case "chewy":
                    calories *= 1.1;
                    break;
                case "homemade":
                    calories *= 1.0;
                    break;
            }
            return calories;
        }
    }
}

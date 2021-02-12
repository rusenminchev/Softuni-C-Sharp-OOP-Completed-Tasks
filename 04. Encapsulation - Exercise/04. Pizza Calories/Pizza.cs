using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int VALID_MINIMUM_NAME_LENGTH = 1;
        private const int VALID_MAXIMUM_NAME_LENGTH = 15;

        private string name;
        private List<Topping> toppings;

        private Pizza()
        {
            toppings = new List<Topping>();
        }
        public Pizza(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < VALID_MINIMUM_NAME_LENGTH || value.Length > VALID_MAXIMUM_NAME_LENGTH)
                {
                    throw new ArgumentException(GlobalConstants
                        .GlobalConstants.InvalidPizzaNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public IReadOnlyCollection<Topping> Toppings => this.toppings.AsReadOnly();

        public double TotalCalories => CalculateTotalCalories();

        private double CalculateTotalCalories()
        {
            double totalCalories = this.Dough.Calories;

            foreach (var topping in toppings)
            {
                totalCalories += topping.Calories;
            }

            return totalCalories;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException(GlobalConstants
                    .GlobalConstants.InvalidNumberOfToppingsExceptionMessage);
            }
            
            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}

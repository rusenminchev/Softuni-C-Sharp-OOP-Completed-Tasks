using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.GlobalConstants
{
    public static class GlobalConstants
    {
        public static string InvalidDoughTypeExceptionMessage =
            "Invalid type of dough.";
        public static string InvalidDoughWeightExceptionMessage =
            "Dough weight should be in the range [1..200].";

        public static string InvalidToppingTypeExceptionMessage =
           "Cannot place {0} on top of your pizza.";
        public static string InvalidToppingWeightExceptionMessage =
           "{0} weight should be in the range[1..50].";

        public static string InvalidPizzaNameExceptionMessage =
            "Pizza name should be between 1 and 15 symbols.";
        public static string InvalidNumberOfToppingsExceptionMessage =
            "Number of toppings should be in range [0..10].";
    }
}

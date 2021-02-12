using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            Pizza pizza = null;

            try
            {
                string[] pizzaArgs = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

                string pizzaName = pizzaArgs[1];
                pizza = new Pizza(pizzaName);

                try
                {

                    string[] doughArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string doughType = doughArgs[1];
                    string doughBakingTechnique = doughArgs[2];
                    double doughWeight = double.Parse(doughArgs[3]);

                    Dough dough = new Dough(doughType, doughBakingTechnique, doughWeight);
                    pizza.Dough = new Dough(doughType, doughBakingTechnique, doughWeight);

                    try
                    {
                        string command = Console.ReadLine();

                        while (command != "END")
                        {
                            string[] commandArgs = command
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Skip(1)
                                .ToArray();

                            string toppingType = commandArgs[0];
                            double toppingWeight = double.Parse(commandArgs[1]);

                            Topping topping = new Topping(toppingType, toppingWeight);
                            pizza.AddTopping(topping);

                            command = Console.ReadLine();
                        }

                        Console.WriteLine(pizza);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            catch (Exception)
            {
                Console.WriteLine(GlobalConstants.GlobalConstants.InvalidPizzaNameExceptionMessage);
            }
        }
    }
}

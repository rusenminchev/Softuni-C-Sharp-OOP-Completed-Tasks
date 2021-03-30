using FoodShortage.Contracts;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoodShortage.Core
{
    public class Engine
    {
        private List<Person> people;

        public Engine()
        {
            people = new List<Person>();
        }

        public void Run()
        {
            AddPeople();
            int totalFoodAmount = 0;
            totalFoodAmount = BuyFood(totalFoodAmount);
            Console.WriteLine(totalFoodAmount);
        }

        private int BuyFood(int totalFoodAmount)
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (this.people.Any(p => p.Name == command))
                {
                    Person person = this.people.First(p => p.Name == command);
                    totalFoodAmount += person.BuyFood();
                }
                command = Console.ReadLine();
            }

            return totalFoodAmount;
        }

        private void AddPeople()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArgs.Length == 4)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string id = commandArgs[2];
                    string birthdate = commandArgs[3];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    this.people.Add(citizen);

                }
                else if (commandArgs.Length == 3)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string group = commandArgs[2];
                    Rebel rebel = new Rebel(name, age, group);
                    this.people.Add(rebel);
                }
            }
        }
    }
}

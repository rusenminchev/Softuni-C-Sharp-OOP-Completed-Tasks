using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private List<Person> people;
        private List<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            
                CreatePeople();
                CreateProducts(); 
           
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = commandArgs[0];
                string productName = commandArgs[1];

                try
                {
                    Person person = this.people.First(p => p.Name == personName);
                    Product product = this.products.First(p => p.Name == productName);
                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

               

                command = Console.ReadLine();
            }
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private void CreateProducts()
        {
            string[] productInput = Console.ReadLine()
                            .Split(';', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            for (int i = 0; i < productInput.Length; i++)
            {
                string[] personArgs = productInput[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string productName = personArgs[0];
                decimal cost = decimal.Parse(personArgs[1]);
                Product product = new Product(productName, cost);
                this.products.Add(product);
            }
        }

        private void CreatePeople()
        {
            string[] peopleInput = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            for (int i = 0; i < peopleInput.Length; i++)
            {
                string[] personArgs = peopleInput[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = personArgs[0];
                decimal money = decimal.Parse(personArgs[1]);
                Person person = new Person(personName, money);
                this.people.Add(person);
            }
        }
    }
}

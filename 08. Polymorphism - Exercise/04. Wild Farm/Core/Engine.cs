using System;
using System.Linq;
using System.Collections.Generic;

using WildFarm.Core.Contracts;
using WildFarm.Factories;
using WildFarm.Models.Animal.Bird;
using WildFarm.Models.Animal.Mammal;
using WildFarm.Models.Animal.Mammal.Feline;
using WildFarm.Models.Contracts;
using WildFarm.Models.Food.Contracts;
using WildFarm.Exceptions;
using WildFarm.IO.Contracts;
using WildFarm.IO.Models;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<IAnimal> animals;
        private FoodFactory foodFactory;
        private IReadable reader;
        private IWritable writer;

        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
            this.reader = new Reader();
            this.writer = new Writer();
        }

        public void Run()
        {
            string command;

            while ((command = this.reader.ReadLine()) != "End")
            {
                IAnimal animal = CreateAnimal(command);
                IFood food = CreateFood();

                this.writer.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidFoodTypeException ifte)
                {
                    this.writer.WriteLine(ifte.Message);
                }

                animals.Add(animal);
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var animal in animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }

        private static IAnimal CreateAnimal(string command)
        {
            string[] animalArgs = command
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            string animalType = animalArgs[0];
            string animalName = animalArgs[1];
            double animalWeight = double.Parse(animalArgs[2]);

            IAnimal animal = null;

            if (animalType == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Owl(animalName, animalWeight, wingSize);
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Hen(animalName, animalWeight, wingSize);
            }
            else if (animalType == "Mouse")
            {
                string livingRegion = animalArgs[3];

                animal = new Mouse(animalName, animalWeight, livingRegion);
            }
            else if (animalType == "Dog")
            {
                string livingRegion = animalArgs[3];

                animal = new Dog(animalName, animalWeight, livingRegion);
            }
            else if (animalType == "Cat")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                animal = new Cat(animalName, animalWeight, livingRegion, breed);
            }
            else if (animalType == "Tiger")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                animal = new Tiger(animalName, animalWeight, livingRegion, breed);
            }

            return animal;
        }

        private IFood CreateFood()
        {
            string[] foodArgs = this.reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string foodType = foodArgs[0];
            int foodQuantity = int.Parse(foodArgs[1]);

            IFood food = foodFactory.ProduceFood(foodType, foodQuantity);
            return food;
        }
    }
}

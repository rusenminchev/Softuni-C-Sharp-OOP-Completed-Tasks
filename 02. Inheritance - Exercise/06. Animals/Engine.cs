using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Animals
{
    class Engine
    {
        private const string END_OF_THE_INPUT_COMMAND = "Beast!";
        private readonly List<Animal> animals;

        public Engine()
        {
            animals = new List<Animal>();
        }

        public void Run()
        {
            string animalType = Console.ReadLine();

            while (animalType != END_OF_THE_INPUT_COMMAND)
            {
                string[] animalDetails = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    this.animals.Add(GetAnimal(animalType, animalDetails));
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }  

                animalType = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animal GetAnimal(string animalType, string[] animalDetails)
        {
            string name = animalDetails[0];
            int age = int.Parse(animalDetails[1]);

            string gender = GetGender(animalDetails);

            Animal animal = null;

            if (animalType == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (animalType == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (animalType == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (animalType == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else if (animalType == "Kitten")
            {
                animal = new Kitten(name, age);
            }

            return animal;
        }

        private static string GetGender(string[] animalDetails)
        {
            string gender = null;
            if (animalDetails.Length >= 3)
            {
                gender = animalDetails[2];
            }

            return gender;
        }
    }
}

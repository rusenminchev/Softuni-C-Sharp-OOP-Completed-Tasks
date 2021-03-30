using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        private List<iBirthable> citizensAndPets;

        public Engine()
        {
            citizensAndPets = new List<iBirthable>();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {

                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArgs[0] == "Citizen")
                {
                    string name = commandArgs[1];
                    int age = int.Parse(commandArgs[2]);
                    string id = commandArgs[3];
                    string birthdate = commandArgs[4];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    this.citizensAndPets.Add(citizen);

                }
                else if (commandArgs[0] == "Pet")
                {
                    string name = commandArgs[1];
                    string birthdate = commandArgs[2];
                    Pet robot = new Pet(name, birthdate);
                    this.citizensAndPets.Add(robot);
                }

                command = Console.ReadLine();
            }

            string birthdateToCheck = Console.ReadLine();

            foreach (var citizenOrAPet in citizensAndPets)
            {
                if (citizenOrAPet.Birthdate.EndsWith(birthdateToCheck))
                {
                    Console.WriteLine(citizenOrAPet.Birthdate);
                }
            }
        }
    }
}

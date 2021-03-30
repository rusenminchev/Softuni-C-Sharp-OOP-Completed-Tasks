using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BorderControl.Core
{
    public class Engine
    {
        private List<IIdentifiable> citizensAndRobots;

        public Engine()
        {
            citizensAndRobots = new List<IIdentifiable>();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "End")
            {

                string[] commandArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArgs.Length == 3)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string id = commandArgs[2];
                    Citizen citizen = new Citizen(name, age, id);
                    this.citizensAndRobots.Add(citizen);

                }
                else if (commandArgs.Length == 2)
                {
                    string model = commandArgs[0];
                    string id = commandArgs[1];
                    Robot robot = new Robot(model, id);
                    this.citizensAndRobots.Add(robot);
                }

                command = Console.ReadLine();
            }

            string fakeIdsLastDigits = Console.ReadLine();

            foreach (var citizen in citizensAndRobots)
            {
                if (citizen.Id.EndsWith(fakeIdsLastDigits))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}

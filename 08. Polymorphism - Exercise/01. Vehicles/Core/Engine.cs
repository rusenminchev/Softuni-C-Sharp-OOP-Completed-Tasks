using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Vehicles.Models;
using _01._Vehicles.Factories;
using _01._Vehicles.Core.Contracts;

namespace _01._Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            Vehicle car = ProduceVehicle();
            Vehicle truck = ProduceVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    ProcessCommand(car, truck, commandArgs);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message); ;
                }
                
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ProcessCommand(Vehicle car, Vehicle truck, string[] commandArgs)
        {
            string command = commandArgs[0];
            string vehicleType = commandArgs[1];

            if (command == "Drive")
            {
                double distance = double.Parse(commandArgs[2]);
                if (vehicleType == "Car")
                {
                    Console.WriteLine(car.Drive(distance));
                }
                else if (vehicleType == "Truck")
                {
                    Console.WriteLine(truck.Drive(distance));
                }
            }
            else if (command == "Refuel")
            {
                double liters = double.Parse(commandArgs[2]); ;
                if (vehicleType == "Car")
                {
                    car.Refuel(liters);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(liters);
                }
            }
        }

        private Vehicle ProduceVehicle()
        {
            string[] vehicleArgs = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            string vehicleType = vehicleArgs[0];
            double fuelQunatity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);

            Vehicle vehicle = vehicleFactory.ProduceVehicle(vehicleType, fuelQunatity, fuelConsumption);
            return vehicle;
        }
    }
}

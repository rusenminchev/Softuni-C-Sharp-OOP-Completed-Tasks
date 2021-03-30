using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using VehiclesExtension.Factories;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VehiclesExtension.Common;

using VehiclesExtension.Core.Contracts;
using VehiclesExtension.Models;
using VehiclesExtension.IO;
using VehiclesExtension.IO.Contracts;
using VehiclesExtension.IO.Models;

namespace VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private IReadable reader;
        private IWritable writer;
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            Vehicle car = ProduceVehicle();
            Vehicle truck = ProduceVehicle();
            Vehicle bus = ProduceVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = this.reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    ProcessCommand(car, truck, bus, commandArgs);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
                
            }
            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
            this.writer.WriteLine(bus.ToString());
        }

        private void ProcessCommand(Vehicle car, Vehicle truck, Vehicle bus, string[] commandArgs)
        {
            string command = commandArgs[0];
            string vehicleType = commandArgs[1];

            if (command == "Drive")
            {
                double distance = double.Parse(commandArgs[2]);
                if (vehicleType == "Car")
                {
                   this.writer.WriteLine(car.Drive(distance));
                }
                else if (vehicleType == "Truck")
                {
                    this.writer.WriteLine(truck.Drive(distance));
                }
                else if (vehicleType == "Bus")
                {
                    this.writer.WriteLine(bus.Drive(distance));
                }
            }
            else if (command == "Refuel")
            {
                double liters = double.Parse(commandArgs[2]);
                
                if (vehicleType == "Car")
                {
                    car.Refuel(liters);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(liters);
                }
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(liters);
                }
            }
            else if (command == "DriveEmpty")
            {
                double distance = double.Parse(commandArgs[2]);
                bus.TurnOffAirConditioner();
                Console.WriteLine(bus.Drive(distance));
            }
        }

        private Vehicle ProduceVehicle()
        {
            string[] vehicleArgs = this.reader.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            string vehicleType = vehicleArgs[0];
            double fuelQunatity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);

            Vehicle vehicle = vehicleFactory.ProduceVehicle(vehicleType, fuelQunatity, fuelConsumption, tankCapacity);
            return vehicle;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using VehiclesExtension.Common;
using VehiclesExtension.Models;

namespace VehiclesExtension.Factories
{
    public class VehicleFactory
    {

        public Vehicle ProduceVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == null)
            {
                throw new InvalidOperationException(ExceptionMessages
                    .INVALID_VEHICLE_TYPE_EXEPTION_MESSAGE);
            }

            return vehicle;
        }
    }
}

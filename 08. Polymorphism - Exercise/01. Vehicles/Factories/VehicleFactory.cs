using _01._Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace _01._Vehicles.Factories
{
    public class VehicleFactory
    {

        public Vehicle ProduceVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle = null;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else if (type == null)
            {
                throw new InvalidOperationException(ExceptionMessages
                    .INVALID_VEHICLE_TYPE_EXEPTIONMESSAGE);
            }

            return vehicle;
        }
    }
}

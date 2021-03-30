using _01._Vehicles.Common;
using _01._Vehicles.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        public Vehicle(double fuelQuantity, double fuelConsumtion)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumtion;
        }

        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumption { get; protected set; }


        public virtual string Drive(double distance)
        {
            double neededFuel = this.FuelConsumption * distance;

            if (FuelQuantity < neededFuel)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages
                    .NOT_ENOUGHT_FUEL_EXCEPTION_MESSAGE, this.GetType().Name));
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}

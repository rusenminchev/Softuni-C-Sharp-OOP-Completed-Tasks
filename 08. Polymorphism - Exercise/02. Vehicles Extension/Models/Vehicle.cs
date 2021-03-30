using System;
using System.Collections.Generic;
using System.Text;

using VehiclesExtension.Common;
using VehiclesExtension.Models.Contracts;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable, IVehicle
    {
        private const double FUEL_QUANTITY_DEFAULT_AMOUNT = 0;

        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumtion, double tankCapacity, bool airConditionerIsWorking = true)
        {
            this.FuelConsumption = fuelConsumtion;
            this.TanksCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.AirConditionerIsWorking = airConditionerIsWorking;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TanksCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TanksCapacity { get; private set; }

        public bool AirConditionerIsWorking { get; private set; }
        public virtual double AirConditionerExtraFuelConsumption { get; private set; }

        public virtual string Drive(double distance)
        {
            double neededFuel = this.FuelConsumption * distance;

            if (AirConditionerIsWorking)
            {
                neededFuel += this.AirConditionerExtraFuelConsumption * distance;
            }

            if (this.FuelQuantity < neededFuel)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages
                    .NOT_ENOUGHT_FUEL_EXCEPTION_MESSAGE, this.GetType().Name));
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }


        public virtual void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TanksCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages
                    .INVALID_MAXIMUM_FUEL_AMOUNT_EXCEPTION_MESSAGE, liters));
            }
            if (liters <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages
                    .INVALID_MINIMUM_FUEL_AMOUNT_EXCEPTION_MESSAGE);
            }
            this.FuelQuantity += liters;
        }
        public void TurnOffAirConditioner()
        {
            this.AirConditionerIsWorking = false;
        }

        public void TurnOnAirConditioner()
        {
            this.AirConditionerIsWorking = true;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }


    }
}

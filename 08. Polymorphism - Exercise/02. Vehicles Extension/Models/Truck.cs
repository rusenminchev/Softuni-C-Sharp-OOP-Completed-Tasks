using System;
using System.Collections.Generic;
using System.Text;

using VehiclesExtension.Common;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double TRUCK_AIRCOND_EXTRA_FUELCONSUMTION = 1.6;
        private const double TRUCK_REFUEL_PERCENTAGE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        { 
        
        }

        public override double AirConditionerExtraFuelConsumption => TRUCK_AIRCOND_EXTRA_FUELCONSUMTION;

        public override void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TanksCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages
                    .INVALID_MAXIMUM_FUEL_AMOUNT_EXCEPTION_MESSAGE, liters));
            }
            
            base.Refuel(liters * TRUCK_REFUEL_PERCENTAGE);
        }
    }
}

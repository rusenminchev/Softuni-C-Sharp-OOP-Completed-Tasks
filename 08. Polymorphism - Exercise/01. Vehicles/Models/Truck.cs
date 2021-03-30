using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TRUCK_AIRCOND_EXTRA_FUELCONSUMTION = 1.6;
        private const double TRUCK_REFUEL_PERCENTAGE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumtion)
            : base(fuelQuantity, fuelConsumtion)
        {

        }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = value + TRUCK_AIRCOND_EXTRA_FUELCONSUMTION;
            }
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * TRUCK_REFUEL_PERCENTAGE);
        }
    }
}

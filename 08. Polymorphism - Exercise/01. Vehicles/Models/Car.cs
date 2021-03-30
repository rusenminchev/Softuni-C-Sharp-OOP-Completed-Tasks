using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CAR_AIRCOND_EXTRA_FUELCONSUMTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumtion)
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
                base.FuelConsumption = value + CAR_AIRCOND_EXTRA_FUELCONSUMTION;
            }
        }
    }
}

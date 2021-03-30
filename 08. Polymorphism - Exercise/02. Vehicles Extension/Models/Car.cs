using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double CAR_AIRCOND_EXTRA_FUELCONSUMTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {

        }

        public override double AirConditionerExtraFuelConsumption => CAR_AIRCOND_EXTRA_FUELCONSUMTION;
    }
}

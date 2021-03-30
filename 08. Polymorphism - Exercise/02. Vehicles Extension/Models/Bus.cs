using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using VehiclesExtension.Common;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double BUS_AIRCOND_EXTRA_FUELCONSUMTION = 1.4;

        public Bus(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {

        }

        public override double AirConditionerExtraFuelConsumption => BUS_AIRCOND_EXTRA_FUELCONSUMTION;
    }
}

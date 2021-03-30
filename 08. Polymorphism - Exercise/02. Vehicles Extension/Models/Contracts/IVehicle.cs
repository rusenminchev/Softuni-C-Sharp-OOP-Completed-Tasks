using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models.Contracts
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public double TanksCapacity { get; }

        public bool AirConditionerIsWorking { get; }

        string Drive(double distance);
        void Refuel(double liters);

        void TurnOnAirConditioner();
        void TurnOffAirConditioner();

    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double DefaultFuelConsumption => 1.25;
        public virtual double FuelConsumption  { get; set; }
        public double Fuel  { get; set; }

        public int HorsePower  { get; set; }

        public virtual void Drive(double travelledKilometers)
        {
            this.Fuel -= (this.DefaultFuelConsumption * travelledKilometers);
        }
    }
}
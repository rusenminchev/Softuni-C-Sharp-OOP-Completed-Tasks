using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;

        public Car(string model, int horsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;         
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < this.MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: { value }.");
                }

                this.horsePower = value;
            }
        }

        public abstract double CubicCentimeters { get; }
        public abstract int MinHorsePower { get; }
        public abstract int MaxHorsePower { get; }

        public abstract double CalculateRacePoints(int laps);
      
    }
}

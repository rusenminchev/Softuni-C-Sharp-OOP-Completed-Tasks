using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        public SportsCar(string model, int horsePower)
            : base(model, horsePower)
        { 
        }

        public override double CubicCentimeters => 3000;

        public override int MinHorsePower => 250;

        public override int MaxHorsePower => 450;

        public override double CalculateRacePoints(int laps)
        {    
                double racePoints = this.CubicCentimeters / this.HorsePower * laps;

                return Math.Round(racePoints);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        public MuscleCar(string model, int horsePower)
            : base(model, horsePower)
        {
        }

        public override double CubicCentimeters => 5000;

        public override int MinHorsePower => 400;

        public override int MaxHorsePower => 600;

        public override double CalculateRacePoints(int laps)
        {
                double racePoints = this.CubicCentimeters / this.HorsePower * laps;

                return Math.Round(racePoints);
           
        }
    }
}

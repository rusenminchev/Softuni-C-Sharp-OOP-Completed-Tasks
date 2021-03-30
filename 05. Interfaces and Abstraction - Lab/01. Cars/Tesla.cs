using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            :base(model,color)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public int Battery { get; set ; }

        public override string Start()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Engine is on!")
                .AppendLine("Silence");

            return sb.ToString().TrimEnd();
        }

        public override string Stop()
        {
            return "The engine is off.";
        }

        public override string ToString()
        {
            return $"{this.Color} { nameof(Tesla)} {this.Model} with {this.Battery} Batteries";
        }
    }
}

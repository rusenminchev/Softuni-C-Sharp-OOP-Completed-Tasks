using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color)
            : base( model, color)
        {

        }
        public override string Start()
        {
            return "Vrooom!";
        }

        public override string Stop()
        {
            return "Engine has stopped!";
        }

        public override string ToString()
        {
            return $"{this.Color} {nameof(Seat)} {this.Model}";
        }
    }
}

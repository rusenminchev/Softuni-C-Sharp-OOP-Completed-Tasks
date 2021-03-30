using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Shapes
{
    public class Circle : Shape
    {
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public int Radius { get; private set; }

        public override double CalculateArea()
        {
            return Math.PI * (Math.Pow(this.Radius, 2));
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Math.PI * this.Radius);
        }

        public override string Draw()
        {
            double rIn = this.Radius - 0.4;

            double rOut = this.Radius + 0.4;

            StringBuilder sb = new StringBuilder();

            for (double y = this.Radius; y >= -this.Radius; --y)
            {

                for (double x = -this.Radius; x < rOut; x += 0.5)
                {

                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)

                        sb.Append("*");

                    else

                        sb.Append(" ");
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}

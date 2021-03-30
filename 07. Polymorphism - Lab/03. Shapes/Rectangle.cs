using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _03._Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }
        public int Height { get; private set; }
        public int Width { get; private set; }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {

            StringBuilder sb = new StringBuilder();

             DrawLine(this.Width, '*', '*', sb);

            for (int i = 1; i < this.Height - 1; ++i)

                DrawLine(this.Width, '*', ' ', sb);

            DrawLine(this.Width, '*', '*', sb);

            return sb.ToString().TrimEnd();

        }

        private void DrawLine(int width, char end, char mid, StringBuilder sb)
        {

            sb.Append(end);

            for (int i = 1; i < width - 1; ++i)

                sb.Append(mid);

            sb.AppendLine(end.ToString());
        }
    }
}

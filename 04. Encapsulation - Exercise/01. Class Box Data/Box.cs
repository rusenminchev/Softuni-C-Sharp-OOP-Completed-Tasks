using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const int MINIMUM_SIDE_VALUE = 0;
        private const string ARGUMENT_EXEPTION_MESSAGE = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                SideValidation(value, nameof(this.Length));
                this.length = value;
            }
        } 

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                SideValidation(value, nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                SideValidation(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double GetSurfaceArea()
        {
            double surfaceArea = 2 * ((this.Length * this.Width) + (this.Length * this.Height) + (this.Width * this.Height));
            return surfaceArea;
        }

        public double GetLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * ((this.Length * this.Height) + (this.Width * this.Height));
            return lateralSurfaceArea;
        }

        public double GetVolume()
        {
            double volume = this.Length * this.Width * this.Height;
            return volume;
        }
        private void SideValidation(double value, string sideName)
        {
            if (value <= MINIMUM_SIDE_VALUE)
            {             
                throw new ArgumentException(String.Format(ARGUMENT_EXEPTION_MESSAGE, sideName));
            }
        } 
    }
}

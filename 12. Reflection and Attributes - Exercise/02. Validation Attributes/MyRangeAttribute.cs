using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            ValidateRange(this.minValue, this.maxValue);

            var value = Convert.ToInt32(obj);

            if (value < this.minValue || value > this.maxValue)
            {
                return false;
            }
            return true;
        }

        private void ValidateRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new InvalidOperationException("Invalid range arguments");
            }
        }
    }
}

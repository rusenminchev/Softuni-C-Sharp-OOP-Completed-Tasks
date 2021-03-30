using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Exceptions
{
    public class InvalidFoodTypeException : Exception
    {
        public InvalidFoodTypeException(string message)
            : base(message)
        {
        }
    }
}

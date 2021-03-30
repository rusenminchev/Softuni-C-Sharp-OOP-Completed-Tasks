using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Exceptions
{
    public class InvalidHeroTypeException : Exception
    {
        private const string INVALID_HERO_TYPE_EXCEPTION_MESSAGE = "Invalid hero!";
        public InvalidHeroTypeException()
            :base(INVALID_HERO_TYPE_EXCEPTION_MESSAGE)
        {
        }

        public InvalidHeroTypeException(string message) : base(message)
        {
        }
    }
}

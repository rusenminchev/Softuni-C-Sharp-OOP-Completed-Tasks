using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string INVALID_CORPS_EXCEPTION_MESSAGE = "Invalid corps!";
        public InvalidCorpsException()
            :base(INVALID_CORPS_EXCEPTION_MESSAGE)
        {
        }

        public InvalidCorpsException(string message) : base(message)
        {
        }
    }
}

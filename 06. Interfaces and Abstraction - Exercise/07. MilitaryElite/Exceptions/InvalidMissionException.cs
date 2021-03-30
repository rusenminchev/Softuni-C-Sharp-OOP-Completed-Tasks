using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionException : Exception
    {
        private const string INVALID_MISSION_EXCEPTION_MESSAGE = "Invalid mission!";
        public InvalidMissionException()
            :base(INVALID_MISSION_EXCEPTION_MESSAGE)
        {

        }

        public InvalidMissionException(string message)
            : base(message)
        {

        }
    }
}

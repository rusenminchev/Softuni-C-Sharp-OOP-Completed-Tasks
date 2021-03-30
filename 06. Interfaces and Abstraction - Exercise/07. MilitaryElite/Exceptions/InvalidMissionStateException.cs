using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string INVALID_MISSION_STATE_EXCEPTION_MESSAGE = "Invalid mission state!";
        public InvalidMissionStateException()
            : base(INVALID_MISSION_STATE_EXCEPTION_MESSAGE)
        {
        }

        public InvalidMissionStateException(string message) : base(message)
        {
        }
    }
}

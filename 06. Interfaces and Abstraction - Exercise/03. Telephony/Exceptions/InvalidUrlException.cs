﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidUrlException : Exception
    {
        private const string INVALID_URL_EXCEPTION_MESSAGE = "Invalid URL!";

        public InvalidUrlException()
           : base(INVALID_URL_EXCEPTION_MESSAGE)

        {

        }

        public InvalidUrlException(string message) : base(message)
        {

        }
    }
}

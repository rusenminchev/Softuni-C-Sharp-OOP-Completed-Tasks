using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exceptions;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        

        public StationaryPhone()
        {

        }

        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Dialing... {number}";
        }
    }
}

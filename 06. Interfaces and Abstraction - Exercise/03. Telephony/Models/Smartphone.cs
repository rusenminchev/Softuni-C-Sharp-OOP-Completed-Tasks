using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Telephony.Exceptions;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {

        }

        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidPhoneNumberException();
            }
            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidUrlException(); 
            }
            return $"Browsing: {url}!";
        }      
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Telephony.Contracts;

namespace Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

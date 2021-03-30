using Raiding.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.IO
{
    class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

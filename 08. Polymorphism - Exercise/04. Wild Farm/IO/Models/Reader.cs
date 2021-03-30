using System;
using System.Text;
using System.Collections.Generic;

using WildFarm.IO.Contracts;

namespace WildFarm.IO.Models
{
    class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }  
}

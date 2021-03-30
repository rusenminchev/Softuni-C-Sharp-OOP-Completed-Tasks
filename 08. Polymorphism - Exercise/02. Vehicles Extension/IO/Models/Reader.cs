using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.IO.Models
{
    class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }  
}

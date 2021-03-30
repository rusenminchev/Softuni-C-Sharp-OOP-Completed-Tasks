using System;
using System.Collections.Generic;
using System.Text;
using VehiclesExtension.IO.Contracts;

namespace VehiclesExtension.IO.Models
{
    public class Writer : IWritable
    {
        public void Write(string text)
        {
            Console.Write(text);
        }
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}

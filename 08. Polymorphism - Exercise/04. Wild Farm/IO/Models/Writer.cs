using System;
using System.Text;
using System.Collections.Generic;

using WildFarm.IO.Contracts;

namespace WildFarm.IO.Models
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

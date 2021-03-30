using Raiding.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.IO
{
    class Writer : IWritable
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

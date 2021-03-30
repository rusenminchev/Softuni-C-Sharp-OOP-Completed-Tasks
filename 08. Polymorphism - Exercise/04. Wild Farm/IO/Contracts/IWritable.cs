using System;
using System.Text;
using System.Collections.Generic;

namespace WildFarm.IO.Contracts
{
    public interface IWritable
    {
        void Write(string text);
        void WriteLine(string text);
    }
}

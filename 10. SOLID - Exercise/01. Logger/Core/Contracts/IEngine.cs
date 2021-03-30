using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Logger.Core.Contracts
{
    public interface IEngine
    {
        void Run();
    }
}

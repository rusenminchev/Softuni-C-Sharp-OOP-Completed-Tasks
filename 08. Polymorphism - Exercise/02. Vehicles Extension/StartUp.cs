using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using VehiclesExtension.Core;
using VehiclesExtension.Core.Contracts;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}

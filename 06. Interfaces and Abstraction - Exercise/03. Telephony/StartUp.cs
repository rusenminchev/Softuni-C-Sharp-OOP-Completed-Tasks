using System;
using System.Linq;
using Telephony.Contracts;
using Telephony.Core;
using Telephony.IO;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}

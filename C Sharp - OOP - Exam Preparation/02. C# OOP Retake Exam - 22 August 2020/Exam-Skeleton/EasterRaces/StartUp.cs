using System;
using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            IChampionshipController controller = new ChampionshipController();
            IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();

            //За по-лесно и по-четимо локално нестване на изходните данни си правим StringBuilderWriter().
            IWriter writer = new StringBuilderWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();

            //За локално нестване. При изпращане в judgе, тези редове се изтриват.
            Console.Clear();
            Console.WriteLine(writer);
        }
    }
}

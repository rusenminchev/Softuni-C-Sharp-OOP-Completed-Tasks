using Logger.Core;
using Logger.Core.Contracts;
using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            ParseAppendersInput(appendersCount, appenders);

            ILogger logger = new Logger.Models.Logger(appenders);

            IEngine engine = new Engine(logger);

            engine.Run();

        }

        private static void ParseAppendersInput(int appendersCount, ICollection<IAppender> appenders)
        {
            AppendersFactory appendersFactory = new AppendersFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];
                string reportLevel = "INFO";

                if (appendersArgs.Length == 3)
                {
                    reportLevel = appendersArgs[2];
                }

                try
                {
                    IAppender appender = appendersFactory
                                        .ProduceAppender(appenderType, layoutType, reportLevel);

                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}

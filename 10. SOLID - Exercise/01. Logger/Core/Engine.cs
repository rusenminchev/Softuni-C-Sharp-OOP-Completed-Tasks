using Logger.Core.Contracts;
using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }
        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string reportLevel = inputArgs[0];
                string dateTime = inputArgs[1];
                string message = inputArgs[2];

                try
                {
                    IError error = this.errorFactory.ProduceError(dateTime, reportLevel, message);
                    this.logger.Log(error);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(this.logger);
        }
    }
}

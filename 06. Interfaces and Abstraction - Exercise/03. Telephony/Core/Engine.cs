using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .ToArray();

            string[] urls = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .ToArray();

            CallPhoneNumber(phoneNumbers);
            BrowseWebSites(urls);
        }

        private void BrowseWebSites(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidUrlException iue)
                {
                    Console.WriteLine(iue.Message); ;
                }
            }
        }

        private void CallPhoneNumber(string[] phoneNumbers)
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(phoneNumber));
                    }
                    else if (phoneNumber.Length == 10)
                    {
                        writer.WriteLine(smartphone.Call(phoneNumber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    Console.WriteLine(ipne.Message);
                }

            }
        }
    }
}

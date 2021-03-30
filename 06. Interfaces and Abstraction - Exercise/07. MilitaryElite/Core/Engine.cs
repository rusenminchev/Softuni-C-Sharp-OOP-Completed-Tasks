using MilitaryElite.Core.Contracts;
using MilitaryElite.IO;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private List<Soldier> soldiers;
        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.soldiers = new List<Soldier>();
        }
        public void Run()
        {
            string command;

            while ((command = this.reader.ReadLine()) != "End")
            {

                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                Soldier soldier = null;

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    List<Private> privates = new List<Private>();

                    for (int i = 5; i < cmdArgs.Length; i++)
                    {
                        int privatesId = int.Parse(cmdArgs[i]);

                        Private @private = (Private)this.soldiers.FirstOrDefault(x => x.Id == privatesId);
                        general.AddPrivate(@private);

                    }
                    soldier = general;
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                   
                        for (int i = 6; i < cmdArgs.Length; i += 2)
                        {
                        try
                        {
                            string repairPart = cmdArgs[i];
                            int repairHours = int.Parse(cmdArgs[i + 1]);

                            Repair repair = new Repair(repairPart, repairHours);
                            engineer.AddRepair(repair);
                        }
                        catch (Exception)
                        {

                            continue;
                        }
                    }

                    soldier = engineer;
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    Commando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < cmdArgs.Length; i += 2)
                    {
                        try
                        {
                            string missionCodeName = cmdArgs[i];
                            string missionState = cmdArgs[i + 1];

                            Mission mission = new Mission(missionCodeName, missionState);
                            commando.AddMission(mission);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                    soldier = commando;
                }
                else if (soldierType == "Spy")
                {
                    int codeName = int.Parse(cmdArgs[4]);
                    soldier = new Spy(id, firstName, lastName, codeName);
                }

                this.soldiers.Add(soldier);
            }

            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}

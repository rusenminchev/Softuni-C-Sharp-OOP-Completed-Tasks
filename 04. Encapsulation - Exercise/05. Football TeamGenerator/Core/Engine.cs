using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;
using FootballTeamGenerator___Refactored.Models;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArgs = input
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = inputArgs[0];

                try
                {
                    if (command == "Team")
                    {
                        AddTeam(inputArgs);

                    }
                    else if (command == "Add")
                    {
                        AddPlayer(inputArgs);

                    }
                    else if (command == "Remove")
                    {
                        RemovePlayer(inputArgs);

                    }
                    else if (command == "Rating")
                    {
                        PrintTeamRating(inputArgs);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                input = Console.ReadLine();
            }
        }

        private void AddTeam(string[] inputArgs)
        {
            string teamName = inputArgs[1];
            Team team = new Team(teamName);
            this.teams.Add(team);
        }

        private void PrintTeamRating(string[] inputArgs)
        {
            string teamName = inputArgs[1];
            ValidateTeamExistance(teamName);

            Team team = this.teams.First(x => x.Name == teamName);
            Console.WriteLine(team);
        }

        private void RemovePlayer(string[] inputArgs)
        {
            string teamName = inputArgs[1];
            string playerName = inputArgs[2];

            Team team = this.teams.First(x => x.Name == teamName);
            team.RemovePlayer(playerName, teamName);
        }

        private void AddPlayer(string[] inputArgs)
        {
            string teamName = inputArgs[1];
            ValidateTeamExistance(teamName);
            Player player = CreatePlayer(inputArgs);
            Team team = this.teams.First(x => x.Name == teamName);
            team.AddPlayer(player);
        }

        private static Player CreatePlayer(string[] inputArgs)
        {
            string playerName = inputArgs[2];
            int endurance = int.Parse(inputArgs[3]);
            int sprint = int.Parse(inputArgs[4]);
            int dribble = int.Parse(inputArgs[5]);
            int passing = int.Parse(inputArgs[6]);
            int shooting = int.Parse(inputArgs[7]);
            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            Player player = new Player(playerName, stats);
            return player;
        }

        private void ValidateTeamExistance(string teamName)
        {
            if (!this.teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(string.Format(GlobalConstants.
                    TeamDoesNotExistExceptionMessage, teamName));
            }
        }
    }
}

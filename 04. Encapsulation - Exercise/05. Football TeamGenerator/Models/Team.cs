using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                 
                return (int)Math.Round((this.players.Sum(x => x.OverallSkillLevel) / this.players.Count));
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName, string teamName)
        {
            if (!this.players.Any(p => p.Name == playerName))
            {
                throw new ArgumentException(string.Format(GlobalConstants
                                            .PlayerIsNotInTheTeamExceptionMessage, playerName, teamName));

            }

            Player player = this.players.First(x => x.Name == playerName);
            this.players.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}

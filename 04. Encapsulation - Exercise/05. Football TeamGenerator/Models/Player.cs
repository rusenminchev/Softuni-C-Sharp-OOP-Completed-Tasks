using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

using FootballTeamGenerator.Common;
using FootballTeamGenerator___Refactored.Models;
using Microsoft.Win32.SafeHandles;

namespace FootballTeamGenerator.Models
{

    public class Player
    {
        private const double NUMBER_OF_STATS = 5.0;
     
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
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
                    throw new ArgumentException(GlobalConstants
                        .InvalidNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public Stats Stats
        {
            get
            {
                return this.stats;
            }
            private set
            {
                this.stats = value;
            }
        }

        public double OverallSkillLevel
        {
            get
            {
                return (this.Stats.Endurance + this.Stats.Sprint + this.Stats.Dribble
                    + this.Stats.Passing + this.Stats.Shooting) / NUMBER_OF_STATS;
            }
        }
    }
}

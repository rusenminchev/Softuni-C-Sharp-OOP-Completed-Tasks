using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Common
{
    public static class GlobalConstants
    {
        public static string InvalidNameExceptionMessage = "A name should not be empty.";

        public static string InvalidPlayerStatsExceptionMessage = "{0} should be between 0 and 100.";

        public static string TeamDoesNotExistExceptionMessage = "Team {0} does not exist.";

        public static string PlayerIsNotInTheTeamExceptionMessage = "Player {0} is not in {1} team.";
    }
}

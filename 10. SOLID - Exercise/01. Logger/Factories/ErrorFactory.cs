using Logger.Common.Global_Constants;
using Logger.Enumerations.Models;
using Logger.Models.Contracts;
using Logger.Models.Errors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        public IError ProduceError(string dateTimeStr,
            string reportLevelTypeStr, string message)
        {

            IError error;

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateTimeStr,
                    GlobalConstants.DATE_TIME_FORMAT, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid date format!", e);
            }

            ReportLevel reportLevel;

            bool hasParsed = Enum.TryParse<ReportLevel>(reportLevelTypeStr, true, out reportLevel);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid report level type!");
            }

            error = new Error(dateTime, reportLevel, message);

            return error;
        }


    }
}

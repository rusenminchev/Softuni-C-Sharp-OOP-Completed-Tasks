using Logger.Enumerations.Models;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            this.DateTime = dateTime;
            this.ReportLevel = reportLevel;
            this.Message = message; 
        } 
        public DateTime DateTime { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public string Message { get; private set; }
}
}

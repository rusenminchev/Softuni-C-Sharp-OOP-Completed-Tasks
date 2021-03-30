using Logger.Enumerations;
using Logger.Enumerations.Models;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }
        ReportLevel ReportLevel { get; }
        string Message { get; }
    }
}

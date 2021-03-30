using Logger.Enumerations.Models;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; }
        int MessagesAppended { get; }
        void Append(IError error);
    }
}

using Logger.Common.Global_Constants;
using Logger.Enumerations.Models;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }
        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            ReportLevel reportLevel = error.ReportLevel;
            string message = error.Message;

            string formatedMessage = String.Format(format,
                dateTime.ToString(GlobalConstants.DATE_TIME_FORMAT,
                CultureInfo.InvariantCulture), reportLevel.ToString(), message);

            Console.WriteLine(formatedMessage);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel.ToString().ToUpper()}," +
                $" Messages appended: {this.MessagesAppended}";
        }
    }
}

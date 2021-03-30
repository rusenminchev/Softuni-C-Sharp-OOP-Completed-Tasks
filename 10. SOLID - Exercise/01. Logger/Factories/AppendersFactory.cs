using Logger.Enumerations.Models;
using Logger.Models.Appenders;
using Logger.Models.Contracts;
using Logger.Models.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class AppendersFactory
    {
        private LayoutFactory layoutFactory;

        public AppendersFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender ProduceAppender(string appenderType,
            string layoutType, string reportLevelType)
        {

            ReportLevel reportLevel;

            bool hasParsed = Enum.TryParse<ReportLevel>(reportLevelType,
                true, out reportLevel);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid report level type!");
            }

            ILayout layout = layoutFactory.ProduceLayout(layoutType);

            IAppender appender = null;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, reportLevel);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile("\\data\\", "logs.txt");

                appender = new FileAppender(layout, reportLevel, file);
            }
            else
            {
                throw new ArgumentException("Invalid appender type");
            }

            return appender;
        }
    }
}

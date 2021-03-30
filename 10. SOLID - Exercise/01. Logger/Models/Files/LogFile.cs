using Logger.Common.Global_Constants;
using Logger.Enumerations.Models;
using Logger.Models.Contracts;
using Logger.Models.IOMenagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private IOMenager IOMenager;
        public LogFile(string folderName, string fileName)
        {
            this.IOMenager = new IOMenager(folderName, fileName);
            this.IOMenager.EnsureDirectoryAndFileExists();
        }

        public string Path => IOMenager.CurrentFilePath;

        public long Size => CalculateFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            ReportLevel reportLevel = error.ReportLevel;
            string message = error.Message;

            string formatedMessage = String.Format(format,
                dateTime.ToString(GlobalConstants.DATE_TIME_FORMAT,
                CultureInfo.InvariantCulture), reportLevel.ToString(), message) + Environment.NewLine;

            return formatedMessage;
        }

        private long CalculateFileSize()
        {
            string text = File.ReadAllText(this.Path);

            long fileSize = text.Where(ch => Char.IsLetter(ch)).Sum(ch => ch);

            return fileSize;
        }
    }
}

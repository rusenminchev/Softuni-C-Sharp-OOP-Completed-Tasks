using Logger.Enumerations.Models;
using Logger.Models.Contracts;
using Logger.Models.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        
        public FileAppender(ILayout layout, ReportLevel reportLevel,
            IFile File)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.File = File;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public IFile File { get; private set; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formatedMessage = this.File.Write(this.Layout, error);

            System.IO.File.AppendAllText(this.File.Path, formatedMessage);
            this.MessagesAppended++;
        }
             public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel.ToString().ToUpper()}," +
                $" Messages appended: {this.MessagesAppended}, File size: {this.File.Size}";
        }
    }
}

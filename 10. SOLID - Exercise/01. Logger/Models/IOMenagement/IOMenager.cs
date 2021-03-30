using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models.IOMenagement
{
    public class IOMenager : IIOMenager
    {
        private string currentPath;

        private string folderName;
        private string fileName;

        private IOMenager()
        {
            this.currentPath = GetCurrentDirectory();
        }
        public IOMenager(string folderName, string fileName)
            :this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }
        public string CurrentDirectoryPath => 
            this.currentPath + this.folderName;

        public string CurrentFilePath => 
            this.CurrentDirectoryPath + this.fileName;

        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            return currentDirectory;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IIOMenager
    {
        string CurrentDirectoryPath { get; }
        string CurrentFilePath { get; }
        string GetCurrentDirectory();
        void EnsureDirectoryAndFileExists();
    }
}

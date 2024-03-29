﻿using P01.Stream_Progress.Contracts;

namespace P01.Stream_Progress
{
    public class File : IStreamable
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }

        public override string ToString()
        {
            return $"{this.name} - {this.Length} - {this.BytesSent}";
        }
    }
}

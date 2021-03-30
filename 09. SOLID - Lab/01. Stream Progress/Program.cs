using P01.Stream_Progress.Contracts;
using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamable music = new Music("Eminem", "The 8 Mile", 45, 1000);
            IStreamable file = new File("Invoice N10035", 3, 1000);

            StreamProgressInfo musicStream = new StreamProgressInfo(music);
            Console.WriteLine(musicStream.CalculateCurrentPercent());

            StreamProgressInfo fileStream = new StreamProgressInfo(file);
            Console.WriteLine(fileStream.CalculateCurrentPercent());

            Console.WriteLine(music);
            Console.WriteLine(file);
        }
    }
}

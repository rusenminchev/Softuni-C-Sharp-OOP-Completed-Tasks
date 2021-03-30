using System;

namespace AuthorProblem
{
    [Author("Maria")] 
    public class StartUp
    {
        [Author("Pijo")]
        [Author("Penda")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            var result = tracker.PrintMethodsByAuthor();


            foreach (var (author, methods) in result)
            {
                var methodsToPrint = string.Join(" ,", methods);

                Console.WriteLine($"{author} - {methodsToPrint}");

            }
        }

        [Author("Pepi")]
        private string SayHello()
        {
            return "Hello";
        }

    }
}

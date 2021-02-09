using System;

namespace CustomRandomList
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Ivan");
            list.Add("Ceco");
            list.Add("Ivo");
            list.Add("Gosho");

            Console.WriteLine(list.RandomString()); ;

            Console.WriteLine();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>()
            {
                "stringOne",
                "stringTwo",
                "stringThree"     
            };

            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.Push("first element");

            stack.AddRange(list);

            Console.WriteLine(stack.IsEmpty());

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

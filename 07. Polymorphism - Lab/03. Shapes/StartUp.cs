using System;
using System.Runtime.CompilerServices;

namespace _03._Shapes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(5, 10);
            Console.WriteLine($"{rectangle.CalculateArea():f2}");
            Console.WriteLine($"{rectangle.CalculatePerimeter():f2}");
            Console.WriteLine(rectangle.Draw());

            Shape circle = new Circle(5);
            Console.WriteLine($"{circle.CalculateArea():f2}");
            Console.WriteLine($"{rectangle.CalculatePerimeter():f2}");
            Console.WriteLine(circle.Draw());

        }
    }
}

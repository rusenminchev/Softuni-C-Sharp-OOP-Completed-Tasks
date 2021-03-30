using FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public abstract class Person : IPerson, IBuyer
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; }
        public int Age { get; }

        public abstract int BuyFood();
       
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MIN_VALID_AGE = 12;
        private const int MAX_VALID_AGE = 90;
        public Person(string fullname, int age)
        {
            this.FullName = fullname;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }
        [MyRange(MIN_VALID_AGE, MAX_VALID_AGE)]
        public int Age { get; private set; }
    }
}

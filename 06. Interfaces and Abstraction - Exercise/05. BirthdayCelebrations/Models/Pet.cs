using BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations.Models
{
    public class Pet : iBirthable
    {
        public Pet(string name, string birhdate)
        {
            this.Name = name;
            this.Birthdate = birhdate;
        }
        public string Name { get; private set; }
        public string Birthdate { get; private set; }
    }
}

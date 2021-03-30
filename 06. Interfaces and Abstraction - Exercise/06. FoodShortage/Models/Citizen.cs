using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

using FoodShortage.Contracts;

namespace FoodShortage
{
    public class Citizen :  Person, IIdentifiable, iBirthable
    {
        private const int VALID_BOUGHT_FOOD = 10;

        public Citizen(string name, int age, string id, string birthdate)
            :base(name,age)
        {
         
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; private set; }
        public string Birthdate { get; private set; }

        public override int BuyFood()
        {
            return VALID_BOUGHT_FOOD;
        }
    }
}

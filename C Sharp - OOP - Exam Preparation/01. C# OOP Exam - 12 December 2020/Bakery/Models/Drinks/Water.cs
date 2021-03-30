﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal WATER_INITIAL_PRICE = 1.50m;
        public Water(string name, int portion, string brand)
            : base(name, portion, brand)
        {

        }
         
        public override decimal Price => WATER_INITIAL_PRICE;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal INITIAL_PRICE_PER_PERSON = 2.50m;

        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity)
        {

        }

        public override decimal PricePerPerson => INITIAL_PRICE_PER_PERSON; 
    }
}

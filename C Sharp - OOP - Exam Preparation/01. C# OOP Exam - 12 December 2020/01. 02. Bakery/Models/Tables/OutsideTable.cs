﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal INITIAL_PRICE_PER_PERSON = 3.50m;

        public OutsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity)
        {
          
        }

        public override decimal PricePerPerson => INITIAL_PRICE_PER_PERSON;
    }
}

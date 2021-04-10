﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price , 3)
        {

        }

        //възможна грешка.
        public override void Eat()
        {
            this.Size += 3;
        }
    }
}

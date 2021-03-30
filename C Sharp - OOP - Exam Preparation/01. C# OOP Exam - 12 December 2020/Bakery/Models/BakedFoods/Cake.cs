using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public class Cake : BakedFood
    {
        private const int INITIAL_CAKE_PORTION = 245;
        public Cake(string name, decimal price)
            : base(name, price)
        {

        }

        public override int Portion => INITIAL_CAKE_PORTION;
    }
}

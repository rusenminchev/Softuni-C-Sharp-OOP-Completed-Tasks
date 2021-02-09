using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Restaurant.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        //Назин за сетване на defaulf-ни стойности при наследяване
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;

        public Coffee(string name, double caffeine)
        : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        double Caffeine { get; }

    }
}

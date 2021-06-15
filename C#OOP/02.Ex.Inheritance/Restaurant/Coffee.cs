using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double defaultMilliliters = 50;
        private const decimal defaultPrice = 3.50m;
        public Coffee(string name, double caffeine) : base(name, defaultPrice, defaultMilliliters)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}

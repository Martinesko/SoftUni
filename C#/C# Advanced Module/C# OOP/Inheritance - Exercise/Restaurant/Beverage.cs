using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public double Milliliters { get; set; }
        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            this.Milliliters = milliliters;
        }
        public class HotBeverage : Beverage
        {
            public HotBeverage(string name, decimal price, double milliliters) : base(name, price, milliliters)
            {
            }
        }
        public class ColdBeverage : Beverage
        {
            public ColdBeverage(string name, decimal price, double milliliters) : base(name, price, milliliters)
            {
            }
        }
        public class Coffee : HotBeverage
        {
            private const double CoffeeMilliliters = 50;
            private const decimal CoffeePrice = 3.50m;
            public double Coffeine { get; set; }
            public Coffee(string name, decimal price, double milliliters,double ceffeine) : base(name, CoffeePrice, CoffeeMilliliters)
            {
                this.Coffeine = ceffeine;
            }
        }
        public class Tea : HotBeverage
        {
            public Tea(string name, decimal price, double milliliters) : base(name, price, milliliters)
            {
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {
        public double Grams {get; set;}
        public Food(string name, decimal price, double grams) : base(name , price)
        {
            this.Grams = grams;
        }
    }
    public class MainDish : Food
    {
        public MainDish(string name, decimal price, double grams) : base(name, price, grams)
        {
        }
    }
    public class Starter : Food
    {
        public Starter(string name, decimal price, double grams) : base(name, price, grams)
        {
        }
    }
    public class Dessert : Food
    {
        public double Calories {get; set;}
        public Dessert(string name, decimal price, double grams, double calories) : base(name, price, grams)
        {
            this.Calories = calories;
        }
    }
    public class Fish : MainDish
    {
        private const double grams = 22;
        public Fish(string name, decimal price) : base(name, price, grams)
        {
        }
    }
    public class Soup : Starter
    {
        public Soup(string name, decimal price, double grams) : base(name, price, grams)
        {
        }
    }
    public class Cake : Dessert
    {
        private const double grams = 250;
        private const double calories = 1000;
        private const decimal price = 5;
        public Cake(string name ) : base(name, price, grams, calories)
        {
        }
    }
}

using System;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
         string orderingProduct = Console.ReadLine();
         int amount = int.Parse(Console.ReadLine());
            switch (orderingProduct)
            {
                case "water":
                    water(orderingProduct, amount);
                    break;
                     case "coffee":
                    coffee(orderingProduct, amount);
                    break;
                     case "coke":
                    coke(orderingProduct, amount);
                    break;
                     case "snacks":
                    snacks(orderingProduct, amount);
                    break;
                default:
                    break;
            }
        }
        static void water (string product , int amount)
        {
            Console.WriteLine($"{(1*amount):F2}");
        }
        static void coffee (string product , int amount)
        {
            Console.WriteLine($"{(1.5*amount):F2}");
        }
        static void  coke (string product , int amount)
        {
            Console.WriteLine($"{(1.4*amount):F2}");
        }
        static void snacks (string product , int amount)
        {
            Console.WriteLine($"{(2*amount):F2}");
        }


    }
}

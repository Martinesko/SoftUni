using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int numberOfProducts = int.Parse(Console.ReadLine());            
            List<string> products = new List<string>();
          
            for (int i = 0; i < numberOfProducts; i++)
            {
            products.Add(Console.ReadLine());
            }
            products.Sort();
            for (int i = 1; i < numberOfProducts+1; i++)
            {              
                Console.WriteLine($"{i}.{products[i-1]}");
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;


namespace Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> storeProductPrice = new SortedDictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();
                if (input[0] == "Revision")
                {
                    break;
                }
                string store = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!storeProductPrice.ContainsKey(store))
                    storeProductPrice.Add(store, new Dictionary<string, double>());

                if (!storeProductPrice.Keys.Contains(product))
                    storeProductPrice[store].Add(product, price);

            }
            foreach (var store in storeProductPrice)
            {
                Console.WriteLine($"{store.Key}->");
                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");                  
                }
            }
        }
    } 
}

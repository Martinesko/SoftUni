using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <string> namePrice = new List<string>();
            double totalPrice = 0; 
            var regex = @"\>>(?<name>[a-zA-Z]+)\<<(?<price>\d+(\.\d+|))\!(?<quantity>\d+)";
            while (true)
            {
              var input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }
                var matches = Regex.Matches(input, regex);
                foreach (Match item in matches)
                {
                    var name = item.Groups["name"].Value;
                    var price = double.Parse(item.Groups["price"].Value) * double.Parse(item.Groups["quantity"].Value);
                    totalPrice += price;
                    namePrice.Add(name);
                }
            }
            Console.WriteLine("Bought furniture:");
            foreach (var item in namePrice)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");

        }
    }
}

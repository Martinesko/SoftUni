using System;
using System.Linq;

namespace Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] vatPrices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(n => double.Parse(n)+double.Parse(n)*0.2).ToArray();
            foreach (var vatPrice in vatPrices)
            {
                Console.WriteLine($"{vatPrice:f2}");
            }
        }
    }
}

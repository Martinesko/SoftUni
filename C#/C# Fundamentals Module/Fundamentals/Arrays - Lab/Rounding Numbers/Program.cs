using System;
using System.Linq;

namespace Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{(decimal)numbers[i]} => {Math.Round((decimal)numbers[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
          double[] input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] sorted = input.OrderByDescending(x => x).ToArray();
            List<double> output = new List<double>();
            if (sorted.Length < 3)
            {
                for (int i = 0; i < sorted.Length; i++)
                {
                    output.Add(sorted[i]);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    output.Add(sorted[i]);
                }
            }
            Console.WriteLine(String.Join(" ",output));
        }
    }
}

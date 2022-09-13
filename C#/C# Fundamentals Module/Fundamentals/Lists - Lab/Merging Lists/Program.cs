using System;
using System.Collections.Generic;
using System.Linq;

namespace Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> first = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> second = Console.ReadLine().Split().Select(double.Parse).ToList();
            int firststart = 0;
            int secondstart = 0;
            int count = first.Count + second.Count;
            List<double> conb = new List<double>(count);
            for (int i = 1; i < first.Count+second.Count+4; i++)
            {
                if (i % 2 != 0)
                {
                    if (firststart < first.Count)
                    {
                     conb.Add(first[firststart]);
                     firststart++;
                    }
                    
                }
                else
                {
                    if (secondstart < second.Count)
                    {
                    conb.Add(second[secondstart]);
                    secondstart++;
                    }
                    
                }
            }
            Console.WriteLine(String.Join(" ",conb));
        }
    }
}

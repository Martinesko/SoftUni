using System;
using System.Linq;
using System.Collections.Generic;

namespace Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();
                foreach (var item in input)
                {
                    elements.Add(item);
                }
            }
            foreach (var item in elements)
            {
                set.Add(item);
            }
            Console.WriteLine(String.Join(" ", set));
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] number = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int start = int.Parse(number[0]);
            int end = int.Parse(number[1]);
            string input = Console.ReadLine();
            List<int> even = new List<int>();
            List<int> odd = new List<int>();
            for (int i = start; i <= end; i++)
                if (i % 2 == 0)
                {
                    even.Add(i);
                }
                else
                {
                    odd.Add(i);
                }
            if (input == "even")
                Console.WriteLine(string.Join(" ", even));
            else if (input == "odd")
                        Console.WriteLine(string.Join(" ", odd));
        }
    }
}

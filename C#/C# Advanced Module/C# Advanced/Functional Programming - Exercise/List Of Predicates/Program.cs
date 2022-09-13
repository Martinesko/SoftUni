using System;
using System.Linq;
using System.Collections.Generic;

namespace List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            List<int> list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (i%dividers[j] != 0)
                    {
                        break;
                    }
                    else if (j >= dividers.Length-1)
                    {
                        list.Add(i);
                    }
                }
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}

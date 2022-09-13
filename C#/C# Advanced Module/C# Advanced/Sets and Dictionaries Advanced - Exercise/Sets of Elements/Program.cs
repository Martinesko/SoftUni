using System;
using System.Linq;
using System.Collections.Generic;

namespace Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            HashSet<int> output = new HashSet<int>();

            for (int i = 0; i < n[0]; i++)
            {
                int input = int.Parse(Console.ReadLine());
                first.Add(input);
            }

            for (int i = 0; i < n[1]; i++)
            {
                int input = int.Parse((Console.ReadLine()));
                second.Add(input);
            }
            foreach (var num1 in first)
            {
                foreach (var num2 in second)
                {
                    if (num1 == num2)
                    {
                        output.Add(num1);
                        break;
                    }

                }
            }
            Console.WriteLine(String.Join(" ",output));
        }
    }
}

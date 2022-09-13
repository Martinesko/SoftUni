using System;
using System.Linq;
using System.Collections.Generic;

namespace Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
           Queue<int> stack = new Queue<int>();
            foreach (var number in input)
            {
                if (number % 2 == 0)
                {
                    stack.Enqueue(number);
                }
            }
                Console.Write(string.Join(", ",stack.ToArray()));             
        }
    }
}

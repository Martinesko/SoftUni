using System;
using System.Linq;
using System.Collections.Generic;

namespace Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            int capacity = int.Parse(Console.ReadLine());
            int current = 0;
            int neededracks = 0;
            foreach (var item in input)
            {
                stack.Push(item);
            }
            while (true)
            {
                current = stack.Pop();
                                
            }
        }
    }
}

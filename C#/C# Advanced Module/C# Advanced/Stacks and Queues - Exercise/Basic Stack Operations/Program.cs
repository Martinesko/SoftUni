using System;
using System.Linq;
using System.Collections.Generic;

namespace Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] stackInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int Min = int.MaxValue;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input[0]; i++)
            {
                stack.Push(stackInput[i]);
            }
            for (int i = 0; i < input[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (stack.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (var item in stack)
                {
                    if (item<Min)
                    {
                        Min = item;
                    }
                }
                Console.WriteLine(Min);
            }
            
        }
    }
}

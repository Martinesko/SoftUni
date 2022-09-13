using System;
using System.Linq;
using System.Collections.Generic;

namespace Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < amount; i++)
            {
                int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
                switch (commands[0])
                {
                    case 1:
                        stack.Push(commands[1]);
                        break;
                    case 2:
                        if (stack.Count<1)
                        {
                            break;
                        }
                        stack.Pop();
                        break;
                    case 3:
                        int Max= int.MinValue;
                        if (stack.Count < 1)
                        {
                            break;
                        }
                        foreach (var item in stack)
                        {
                            if (item > Max)
                            {
                                Max = item;
                            }
                        }
                        Console.WriteLine(Max);
                        break;
                    case 4:
                        int Min = int.MaxValue;
                        if (stack.Count < 1)
                        {
                            break;
                        }
                        foreach (var item in stack)
                        {
                            if (item<Min)
                            {
                                Min = item;
                            }
                        }
                        Console.WriteLine(Min);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(String.Join(", ",stack));
        }
    }
}

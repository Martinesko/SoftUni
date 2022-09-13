using System;
using System.Linq;
using System.Collections.Generic;

namespace Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] queueInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int Min = int.MaxValue;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < input[0]; i++)
            {
                queue.Enqueue(queueInput[i]);
            }
            for (int i = 0; i < input[1]; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (queue.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (var item in queue)
                {
                    if (item < Min)
                    {
                        Min = item;
                    }
                }
                Console.WriteLine(Min);
            }

        }
    }
}

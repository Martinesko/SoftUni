using System;
using System.Linq;
using System.Collections.Generic;

namespace Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int Max = int.MinValue;
            Queue<int> queue = new Queue<int>();
            foreach (int item in input)
            {
                if (item > Max)
                {
                    Max = item;
                }
                queue.Enqueue(item);
            }
            while (true)
            {
                if (queue.Count < 1)
                {
                    break;
                }
                else if (quantity - queue.Peek() > 0)
                {
                    quantity -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(Max);
            if (queue.Count>=1)
            {
                Console.WriteLine($"Orders left: {String.Join(" ",queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}

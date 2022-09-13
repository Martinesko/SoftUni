using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {            //10 20 30 3|| 20  || 30 10 20 || 10 30 20 
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            int range = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            
            string name = "";
            string removed = "";
            for (int i = 0; i < input.Length; i++)
            {
                queue.Enqueue(input[i]);
            }
            while (queue.Count != 1)
            {
                for (int i = 0; i < range - 1; i++)
                {
                    name = queue.Dequeue();
                    queue.Enqueue(name);
                }
                removed = queue.Dequeue();
                Console.WriteLine($"Removed {removed}");
            }
            foreach (var item in queue)
                Console.WriteLine($"Last is {item}");
        }

    }
}

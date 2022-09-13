using System;
using System.Linq;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
         Queue<string> queue = new Queue<string>();
         List<string> stack = new List<string>();
            while (true)
            {
               string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                else if(command == "Paid")
                {
                    for (int i = queue.Count; i > 0; i--)
                    {
                       stack.Add(queue.Dequeue());
                    }   
                }
                else
                queue.Enqueue(command);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}

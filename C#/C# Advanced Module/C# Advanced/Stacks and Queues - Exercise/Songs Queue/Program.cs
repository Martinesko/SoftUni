using System;
using System.Linq;
using System.Collections.Generic;

namespace Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();
            Queue<string> queue = new Queue<string>();
            foreach (var item in input)
            {
                queue.Enqueue(item);
            }
            bool isempty = false;
            string name = "";
            while (isempty != true)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                switch (command[0])
                {
                    case "Play":
                        if (queue.Count-1 < 1)
                        {
                            isempty = true;
                            Console.WriteLine("No more songs!");
                            break;
                        }
                        queue.Dequeue();
                        break;
                    case "Add":
                        for (int i = 1; i < command.Length; i++)
                        {
                            if (i == 1)
                            {
                                name = command[1];
                            }
                            else
                            {
                                name += $" {command[i]}";
                            }
                            
                        }
                        if (queue.Contains(name))
                        {
                            Console.WriteLine($"{name} is already contained!");
                            break;
                        }
                        queue.Enqueue(name);
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", queue));
                        break;
                    default:
                        break;
                }
            }

        }
    }
}

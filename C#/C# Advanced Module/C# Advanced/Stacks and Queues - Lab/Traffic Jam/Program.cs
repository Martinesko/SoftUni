using System;
using System.Linq;
using System.Collections.Generic;

namespace Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passes = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int counter = 0;
            while (true)
            {
             string car = Console.ReadLine();
                if (car == "green")
                {
                    for (int i = 0; i < passes; i++)
                    {
                        if (queue.Count < 1)
                        {
                            break;
                        }
                        counter++;
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                    }
                }
                else if (car == "end")
                {
                    break;
                }
                else
                {
                    queue.Enqueue(car);
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}

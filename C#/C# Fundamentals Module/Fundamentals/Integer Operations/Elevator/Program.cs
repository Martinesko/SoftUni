using System;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int lastcourse = 0;
            int counter = 0;
            if (n % capacity != 0)
            {
               lastcourse = n % capacity;
                counter++;
                n -= lastcourse;
            }
            counter += n / capacity;
            Console.WriteLine(counter);
            
        }
    }
}

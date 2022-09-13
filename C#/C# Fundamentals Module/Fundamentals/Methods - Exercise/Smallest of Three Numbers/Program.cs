using System;

namespace Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            lowest(first, second, third);
        }
        static void lowest(int first, int second, int third)
        {
            int lowest = int.MaxValue;
            if (first<= lowest)
            {
               lowest = first;
            }
            if (second<= lowest)
            {
                lowest = second ;
            }
            if (third<= lowest)
            {
                lowest = third;
            }
            Console.WriteLine(lowest);
        }
    }
}

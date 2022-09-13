using System;

namespace Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            charLoop(start, end);
        }
        static void charLoop(char start, char end)
        {
            if (start < end)
            {
                for (int i = start + 1; i <= end - 1; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
            else
            {
            for (int i = end+1; i <= start-1; i++)
            {
                Console.Write($"{(char)i} ");
            }
            }
            
        }
    }
}

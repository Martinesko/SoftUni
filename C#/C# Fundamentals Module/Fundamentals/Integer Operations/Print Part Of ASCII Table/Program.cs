using System;

namespace Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int bottom = int.Parse(Console.ReadLine());
            int top = int.Parse(Console.ReadLine());
            for (int i = bottom; i <= top; i++)
            {
                Console.Write($"{(char)i} ");

            }
        }
    }
}

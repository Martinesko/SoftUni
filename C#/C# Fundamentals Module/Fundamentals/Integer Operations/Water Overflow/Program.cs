using System;

namespace Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capasity = 255;
            int counter = int.Parse(Console.ReadLine());
            int output = 0;
            for (int i = 0; i < counter; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (output + input > capasity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    output += input;
                }
            }
            Console.WriteLine(output);
        }
    }
}

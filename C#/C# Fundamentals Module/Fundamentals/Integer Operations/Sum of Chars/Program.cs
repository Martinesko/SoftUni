using System;

namespace Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
        int counter = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < counter; i++)
            {
                char input = char.Parse(Console.ReadLine());
                sum += (int)(input);
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}

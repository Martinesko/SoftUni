using System;

namespace Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int h = 0; h < n; h++)
                    {
                        Console.WriteLine($"{(char)(i+97)}{(char)(j+97)}{(char)(h+97)}");
                    }
                }
            }
        }
    }
}

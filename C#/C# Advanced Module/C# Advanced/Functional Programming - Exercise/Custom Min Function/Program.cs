using System;
using System.Linq;

namespace Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n=> int.Parse(n)).ToArray();
            int n = numbers.Min();
            Console.WriteLine(n);
        }
    }
}

using System;
using System.Linq;

namespace Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).Reverse().ToArray();
          int given = int.Parse(Console.ReadLine());
            int[] output = numbers.Where(n=> n%given != 0).ToArray();
            Console.WriteLine(String.Join(" ", output));
        }
    }
}

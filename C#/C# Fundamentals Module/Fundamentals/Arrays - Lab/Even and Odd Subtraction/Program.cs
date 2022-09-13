using System;
using System.Linq;

namespace Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evenNumberssum  = 0;
            int oddNumberssum = 0;
            int totalSum = 0;
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumberssum += number;
                }
                else
                {
                    oddNumberssum += number;
                }
            }
            totalSum = evenNumberssum - oddNumberssum;
            Console.WriteLine(totalSum);
        }
    }
}

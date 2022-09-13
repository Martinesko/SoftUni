using System;

namespace Methods___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int givenNumber = int.Parse(Console.ReadLine());
            test(givenNumber);
        }
        static void test (int givenNumber)
        {
            if (givenNumber > 0)
            {
                Console.WriteLine($"The number {givenNumber} is positive. ");
            }
            else if (givenNumber < 0)
            {
                Console.WriteLine($"The number {givenNumber} is negative. ");
            }
            if (givenNumber == 0)
            {
                Console.WriteLine($"The number {givenNumber} is zero. ");
            }
        }
    }
}

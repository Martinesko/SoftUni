using System;
using System.Linq;

namespace Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int first = int.MinValue;
            int currentNumber = 0;
            int startingPointOfArry = 0;
            for (int i = 0; i < arry.Length; i++)
            {
                currentNumber = arry[i];
                if (currentNumber > first)
                {
                    first = currentNumber;
                    startingPointOfArry = i;
                }
            }
            for (int i = startingPointOfArry; i < arry.Length; i++)
            {
                Console.Write($"{arry[i]} ");
            }

        }
    }
}

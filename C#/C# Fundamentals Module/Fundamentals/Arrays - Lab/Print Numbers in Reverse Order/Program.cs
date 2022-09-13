using System;

namespace Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int rangeofarry = int.Parse(Console.ReadLine());
            int[] numbers = new int[rangeofarry];

            for (int i = 0; i <= rangeofarry-1; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            for (int i = rangeofarry-1;i >= 0; i--)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}

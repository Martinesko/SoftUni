using System;
using System.Linq;

namespace Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    array[i] += array[i + 1];
                }
            }

            Console.WriteLine(array[0]);
        }
    }
}

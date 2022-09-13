using System;
using System.Linq;

namespace Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstNumberArry = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secoundNumberArry = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            bool flag = false;
            for (int i = 0; i < firstNumberArry.Length; i++)
            {
                if (firstNumberArry[i] != secoundNumberArry[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    flag = true;
                    return;
                }
                sum = firstNumberArry[i];
            }
            if (flag != true)
            {
                sum += sum;
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

        }
    }
}

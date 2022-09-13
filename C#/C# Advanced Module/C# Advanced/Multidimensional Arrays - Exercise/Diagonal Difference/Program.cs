using System;
using System.Linq;
using System.Collections.Generic;

namespace Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int sum1 = 0;
            int sum2 = 0;
            int lab = 0;
            for (int i = 0; i < size; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            for (int i = 0; i < size; i++)
            {
             sum1 += matrix[i, i];
            }
            for (int i = size-1; i >= 0; i--)
            {
                for (int j = lab; j < lab+1; j++)
                {
                    sum2 += matrix[j, i];
                    lab++;
                    break;
                }
            }
            int totalsum = sum1 - sum2;
            Console.WriteLine(Math.Abs(totalsum));
        }
    }
}

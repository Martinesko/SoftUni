using System;
using System.Linq;

namespace Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            for (int i = 0; i < size; i++)
            {
                int[] inputedMatrix = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i , j] = inputedMatrix[j];
                }
            }
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, i]; 
            }
            Console.WriteLine(sum);
        }
    }
}

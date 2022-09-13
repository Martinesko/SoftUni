using System;
using System.Linq;

namespace Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] inputedMatrix = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = inputedMatrix[j];
                }
            }
            for (int i = 0; i < cols; i++)
            {
                sum = 0;
                for (int j = 0; j < rows; j++)
                {
                   sum += matrix[j, i];
                }
                Console.WriteLine(sum);
            }
               
          
           
        }
    }
}

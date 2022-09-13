using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] inputedMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = inputedMatrix[j];
                }
            }
            long maxSum = long.MinValue;
            int bestRow = 0, bestCol = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    long sum =
                        matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            Console.WriteLine(matrix[bestRow, bestCol] + " " + matrix[bestRow, bestCol + 1]);
            Console.WriteLine(matrix[bestRow + 1, bestCol] + " " +matrix[bestRow + 1, bestCol + 1]);
            Console.WriteLine(maxSum);
        }
    }
}

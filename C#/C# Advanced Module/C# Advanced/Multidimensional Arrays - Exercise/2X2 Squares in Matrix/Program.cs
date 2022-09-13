using System;
using System.Linq;

namespace _2X2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = new string[rows, cols];
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int first = row++;
                    int second = col++;
                    if (matrix[row, col] == matrix[row, second] && matrix[row, col] == matrix[first, col] && matrix[row, col] == matrix[first, second])
                    {
                        counter = 1;
                        counter++;
                    }
                }
            }  
                Console.WriteLine(counter);

        }
    }
}

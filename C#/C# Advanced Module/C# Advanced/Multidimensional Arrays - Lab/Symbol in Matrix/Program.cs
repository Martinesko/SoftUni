using System;
using System.Linq;

namespace Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            bool isThere = false;
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                char[] inputedMatrix = input.ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = (int)inputedMatrix[j];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            int ASCIINumberOfSymbol = (int)symbol;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    if (matrix[i, j] == ASCIINumberOfSymbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isThere = true;
                        break;
                        
                    }
                    
                }
                if (isThere == true)
                {
                    break;
                }
                if (size-1 == i)
                {
                    Console.WriteLine($"{symbol} does not occur in the matrix");
                }
            }

        }
    }
}
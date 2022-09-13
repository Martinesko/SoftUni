using System;
using System.Linq;
using System.Numerics;

namespace Pascal_Triangle
{
    internal class Program
    {
        //1 
        //1 1 
        //1 2 1 
        //1 3 3 1

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            BigInteger[][] triangle = new BigInteger[size][];
            
            for (int row = 0; row < size; row++)
            {
                triangle[row] = new BigInteger[row+1];
                triangle[row][0] = 1;
                for (int col = 1; col < row; col++)
                {
                    triangle[row][col] = triangle[row - 1][col-1] + triangle[row - 1][col];
                }
                triangle[row][row] = 1;
            }           
                for (int i = 0; i < triangle.Length; i++)
                {
                         Console.WriteLine(String.Join(" ", triangle[i]));
                }
        }
    }
}

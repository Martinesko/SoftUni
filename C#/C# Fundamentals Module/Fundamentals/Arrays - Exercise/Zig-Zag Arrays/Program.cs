using System;
using System.Linq;

namespace Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int penis = int.Parse(Console.ReadLine());
            int[] arryleft = new int[penis];
            int[] arryright = new int[penis];
            for (int rows = 1; rows <= penis; rows++)
            {
                int[] currntarry = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (rows % 2 == 0)
                {
                    arryleft[rows - 1] += currntarry[0];
                    arryright[rows - 1] += currntarry[1];
                }
                else
                {
                    arryleft[rows - 1] += currntarry[1];
                    arryright[rows - 1] += currntarry[0];
                }
            }
            Console.WriteLine(String.Join(" ", arryright));
            Console.WriteLine(String.Join(" ", arryleft));
        }
    }
}

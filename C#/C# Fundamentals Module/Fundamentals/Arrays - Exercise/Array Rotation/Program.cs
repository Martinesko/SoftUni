using System;
using System.Linq;

namespace Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int firstdigit = arry[0];
                for (int j = 0; j < arry.Length - 1; j++)
                {
                    arry[j] = arry[j + 1];
                }
                arry[arry.Length - 1] = firstdigit;
            }
            Console.WriteLine(String.Join(" ", arry));
        }
    }
}

using System;

namespace Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tallestPoint = int.Parse(Console.ReadLine());
            TopPart(tallestPoint);
            BottomPart(tallestPoint);
        }
        static void TopPart(int tallestPoint)
        {
            for (int i = 1; i < tallestPoint+1; i++)
            {

                for (int j = 1; j < i; j++)
                {
                    Console.Write(j+ " ");
                }
                Console.WriteLine();
            }
        }
        static void BottomPart(int tallestPoint)
        {
            for (int i = tallestPoint+1; i > 0 ; i--)
            {

                for (int j = 1; j < i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

    }
}

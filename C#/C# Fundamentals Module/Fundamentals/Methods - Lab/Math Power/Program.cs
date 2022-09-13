using System;

namespace Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());
            double sum = 0;
            powing(baseNumber, pow);
        }
        static void powing(double baseNumber , double pow ) 
        {
            double sum = baseNumber;
            for (double i = 0; i < pow-1; i++)
            {
                sum *= baseNumber;               
            }
            Console.WriteLine(sum);
        }
    }
}

using System;

namespace Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = int.Parse(Console.ReadLine());
            double b = int.Parse(Console.ReadLine());
            double area = 0;
            Formula(a, b, area);
        }
        static void Formula(double a , double b , double area)
        {
            area = (a * b);
            Console.WriteLine(area);
        }
    }
}

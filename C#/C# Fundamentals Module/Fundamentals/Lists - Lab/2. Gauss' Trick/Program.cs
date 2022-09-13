using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> number = Console.ReadLine().Split().Select(double.Parse).ToList();
            int end = number.Count-1;
            for (int start = 0; start < number.Count-1; start++)
            {
                if (start >= end - start)
                {
                break;
                }
                else
                {
                 number[start] += number[end-start];
                 number.RemoveAt(end-start);
                }
                
            }
            Console.WriteLine(String.Join(" ", number));
        }
    }
}

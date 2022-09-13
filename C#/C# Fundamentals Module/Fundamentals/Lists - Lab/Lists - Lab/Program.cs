using System;
using System.Collections.Generic;
using System.Linq;
namespace Lists___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            int lenght = numbers.Count;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i >= lenght)
                {
                    break;
                }
                else
                {
                  if (numbers[i] == numbers[i+1])
                 {
                    
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i+1);
                    i-= 1;
                   
                }
                }                                              
            }
            Console.WriteLine(String.Join(" ",numbers));
        }
    }
}

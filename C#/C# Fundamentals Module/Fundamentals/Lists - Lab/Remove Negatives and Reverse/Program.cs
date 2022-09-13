using System;
using System.Collections.Generic;
using System.Linq;

namespace Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
          List<double> numbersList = Console.ReadLine().Split().Select(double.Parse).ToList();
            for (int i = 0; i < numbersList.Count; i++)
            {
                if (numbersList[i] < 0)
                {
                    numbersList.RemoveAt(i);
                    i--;
                }
            }
            if (numbersList.Any())
            {
             for (int i = numbersList.Count-1; i >= 0; i--)
            {
                Console.Write($"{numbersList[i]} ");
            }  
            }
            else
            {
                Console.WriteLine("empty");
            }
                 
        }
    }
}

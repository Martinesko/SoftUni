using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine().Split().Select(int.Parse).ToList();
             List<int> secondList = new List<int>();
            List<int> filteredList = new List<int>();

            int sum = 0;
            for (int i = 0; i < numberList.Count; i++)
            {
                sum += numberList[i];
            }
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] > sum/numberList.Count)
                {
                    secondList.Add(numberList[i]);
                }
            }
            for (int i = 0; i < length; i++)
            {

            }
            Console.WriteLine(string.Join(" ", secondList));
        }
    }
}

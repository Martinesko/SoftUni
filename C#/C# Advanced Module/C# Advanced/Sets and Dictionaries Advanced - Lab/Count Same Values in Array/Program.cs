using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
         Dictionary<double , int> dic = new Dictionary<double , int>();
         List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();
            foreach (var item in input)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}

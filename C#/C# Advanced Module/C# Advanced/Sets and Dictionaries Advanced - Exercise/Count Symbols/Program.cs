using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
           char[] input = Console.ReadLine().ToArray();
            SortedDictionary<char , int > dic = new SortedDictionary<char , int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!dic.ContainsKey(input[i]))
                {
                    dic.Add(input[i], 0);
                }
                dic[input[i]]++;
            }
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}

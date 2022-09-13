using System;
using System.Collections.Generic;
using System.Linq;

namespace Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(" ").ToList();
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length % 2 == 0)
                {

                }
                else
                {
                  words.RemoveAt(i);
                    i =- 1;
                }
            }
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}

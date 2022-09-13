using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dic = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string , Dictionary<string , bool >> isFound = new Dictionary<string , Dictionary<string , bool>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] colorInput = Console.ReadLine().Split(" -> ").ToArray();
                string color = colorInput[0];
                string[] Types = colorInput[1].Split(",").ToArray();
                if (!dic.ContainsKey(color))
                {
                    dic.Add(color, new Dictionary<string, int>());
                    isFound.Add(color, new Dictionary<string, bool>());

                }
                foreach (var type in Types)
                {

                    if (!dic[color].ContainsKey(type))
                    {
                        dic[color].Add(type,0);
                        isFound[color].Add(type,false);
                    }
                    dic[color][type]++;   
                }
            }
            string[] input = Console.ReadLine().Split(" ").ToArray();
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var type in item.Value)
                {
                    Console.Write($"* {type.Key} - {type.Value}");
                    if (type.Key == input[1] && item.Key == input[0])
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

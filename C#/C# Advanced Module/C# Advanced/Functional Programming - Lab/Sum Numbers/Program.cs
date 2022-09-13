using System;
using System.Linq;

namespace Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {string str = Console.ReadLine();
            int sum = str.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).Sum();
            int n = str.Split(", ").Length;
            Console.WriteLine(n);
            Console.WriteLine(sum);
        }
    }
}

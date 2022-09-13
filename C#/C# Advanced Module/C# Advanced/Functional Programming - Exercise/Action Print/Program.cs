using System;
using System.Linq;

namespace Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
          string[] str = Console.ReadLine().Split(" ").ToArray();
            foreach (var word in str)
            {
                Console.WriteLine(word);
            }
        }
    }
}

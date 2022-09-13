using System;
using System.Linq;

namespace Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(" ").Where(n => n.Length <= number).ToArray();
            foreach (var name in str)
            {
                Console.WriteLine(name);
            }
        }
    }
}

using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> IsUpper = n => n[0] == n.ToUpper()[0];
            string[] str = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(n => IsUpper(n)).ToArray();
            foreach (var words in str)
            {
                Console.WriteLine(words);
            }
        }
    }
}

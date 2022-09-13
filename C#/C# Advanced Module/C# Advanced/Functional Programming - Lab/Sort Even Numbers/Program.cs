using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] evenNumbers = Console.ReadLine().Split(new string[] {", "},StringSplitOptions.RemoveEmptyEntries).Select(n=> int.Parse(n)).Where(n=> n % 2 == 0).OrderBy(n => n).ToArray();
            Console.Write(String.Join(", ",evenNumbers));
        }
    }
}

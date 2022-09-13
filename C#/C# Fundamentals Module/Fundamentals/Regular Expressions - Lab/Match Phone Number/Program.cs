using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ", Regex.Matches(Console.ReadLine(), @"\+359( |-)2\1\d{3}\1\d{4}\b").Select(x => x.Value).ToList()));
        }
    }
}

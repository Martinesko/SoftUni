using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string names = Console.ReadLine();
         string regex = @"\b[A-Z][a-z]+[ ][A-Z][a-z]+";
            
            MatchCollection matechednames = Regex.Matches(names, regex);
            foreach (var item in matechednames)
            {
                Console.Write(item + " ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
         List<string> wordList = Console.ReadLine().Split().ToList();
            string finalString = "";
            for (int i = 0; i < wordList.Count; i++)
            {
                string loopedword = wordList[i];
                for (int j = 0; j < loopedword.Length; j++)
                {
                    finalString += loopedword;
                }

            }
            Console.WriteLine(finalString);
        }
    }
}

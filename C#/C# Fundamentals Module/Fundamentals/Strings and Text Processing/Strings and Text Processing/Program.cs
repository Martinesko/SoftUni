using System;
using System.Linq;
using System.Collections.Generic;


namespace Strings_and_Text_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string , string> wordAndReverstWord = new Dictionary<string , string>();
            while (true)
            {
             string word = Console.ReadLine();
                if (word == "end")
                {
                    break;
                }
                wordAndReverstWord.Add(word, "");
                string reversedWord = "";
                for (int i = word.Length-1; i >= 0; i--)
                {
                    reversedWord += word[i];
                }
                wordAndReverstWord[word] = reversedWord;
            }
            foreach (var item in wordAndReverstWord)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }
    }
}

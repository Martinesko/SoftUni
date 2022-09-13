using System;
using System.Collections.Generic;
using System.Linq;


namespace Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int reps = int.Parse(Console.ReadLine());
            var synonymDic = new Dictionary<string, List<string>>();
           
            for (int i = 0; i < reps; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (synonymDic.ContainsKey(word))
                {
                    synonymDic[word].Add(synonym);
                }
                else
                {
                    List<string> newlist = new List<string>();
                    newlist.Add(synonym);
                    synonymDic.Add(word, newlist);
                }
            }
            foreach (var item in synonymDic)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}

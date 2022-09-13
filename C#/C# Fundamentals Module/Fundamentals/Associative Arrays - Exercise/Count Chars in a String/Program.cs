using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
         var charDic = new Dictionary<string, int>();
         string text = Console.ReadLine();
         List<char> charList = text.ToList();

            foreach (var chare in charList)
            {
                if (chare != 32)
                {
                 string letter = chare.ToString();
                if (charDic.ContainsKey(letter))
                {
                    charDic[letter]++;
                }
                else
                {
                    charDic.Add(letter, 1);
                }
                }
                else
                { 
                
                }
                
            }
            foreach (var item in charDic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}

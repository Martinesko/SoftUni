using System;

namespace Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
         char[] word = Console.ReadLine().ToLower().ToCharArray();
            int numberOfVowels = 0;
            VowelsChecker(word, numberOfVowels);
        }
        static void VowelsChecker(char[] word,int numberOfVowels) 
        {

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 97 || word[i] == 101 || word[i] == 105 || word[i] == 111 || word[i] == 117)
            {
                    numberOfVowels++;
            }
            }
            Console.WriteLine(numberOfVowels);
        }
    }
}

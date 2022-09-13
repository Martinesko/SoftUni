using System;

namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var wordsReader = new StreamReader(wordsFilePath);
            using (wordsReader)
            {
                string[] words = wordsReader.ReadToEnd().Split(" ").ToArray();
            }
            var textReader = new StreamReader(textFilePath);
            using (textReader)
            {
                string[] text = textReader.ReadToEnd().Split(" "); 
            }



        }
    }
}

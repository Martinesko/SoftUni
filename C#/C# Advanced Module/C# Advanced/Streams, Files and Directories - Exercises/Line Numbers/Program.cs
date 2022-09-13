namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            int counter = 0;
            string[] lines = File.ReadAllLines(inputFilePath);
            StreamWriter streamWriter = new StreamWriter(File.Create(outputFilePath));
            using (streamWriter)
            {
                foreach (string line in lines)
                {
                    counter++;
                    int Letters = line.Count(char.IsLetter);
                    int Punct = line.Count(char.IsPunctuation);

                    streamWriter.WriteLine($"Line {counter}: {line} ({Letters})({Punct})");

                }
            }       
        }
    }
}

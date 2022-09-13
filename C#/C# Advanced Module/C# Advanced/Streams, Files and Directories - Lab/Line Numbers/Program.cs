using System;

namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);
            int counter = 0;
            using (reader)
            {
                string line = reader.ReadLine();
                using (writer)
                {
                    while (line != null)
                    {
                        counter++;
                        writer.WriteLine($"{counter}. {line}");
                        line = reader.ReadLine();
                    }

                }

            }
        }
    }
}

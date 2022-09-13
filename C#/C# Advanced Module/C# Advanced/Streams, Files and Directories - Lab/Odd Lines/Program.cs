using System;

namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var writer = new StreamWriter(outputFilePath);

            int curline = 0;
            using (reader)
            {
                string line = reader.ReadLine();
                using (writer)
                {
                    while (line != null)
                    {
                        if (curline % 2 == 1)
                            writer.WriteLine(line);
                        line = reader.ReadLine();
                        curline++;
                    }
                }
            }
        }
    }
}

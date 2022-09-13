using System;

namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var firstReader = new StreamReader(firstInputFilePath);
            var secondReader = new StreamReader(secondInputFilePath);
            var outputWriter = new StreamWriter(outputFilePath);

            using (firstReader)
            {
                string firstLine = firstReader.ReadLine();
                using (secondReader)
                {
                    string secondLine = secondReader.ReadLine();
                    using (outputWriter)
                    {
                        while (firstLine != null && secondLine != null)
                        {
                            if (firstLine != null)
                            {
                                outputWriter.WriteLine(firstLine);
                            }
                            if (secondLine != null)
                            {
                                outputWriter.WriteLine(secondLine);
                            }
                            firstLine = firstReader.ReadLine();
                            secondLine = secondReader.ReadLine();
                        }
                    }

                }
            }
        }
    }
}

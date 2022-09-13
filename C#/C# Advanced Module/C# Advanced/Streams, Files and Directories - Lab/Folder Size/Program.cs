using System;

namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
           double sum = 0; 
            var writer = new StreamWriter(outputFilePath);
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo info in infos)
            {
                sum = info.Length;
            }
            sum = sum / 2024;
            using (writer)
            {
                writer.WriteLine($"{sum:f10}");
            }
        }
    }
}

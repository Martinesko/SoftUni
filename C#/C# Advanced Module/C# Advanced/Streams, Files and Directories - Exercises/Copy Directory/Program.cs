namespace CopyDirectory
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";//C:\Users\meane\Desktop\Task_1\images
            string outputPath = @$"{Console.ReadLine()}";//C:\Users\meane\Desktop\Task_2

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);
            string[] files = Directory.GetFiles(inputPath);
            foreach (var file in files)
            {
                var filename = Path.GetFileName(file);
                var copyDistination = Path.Combine(outputPath, filename);
                File.Copy(file, copyDistination);
            }
        }
    }
}

namespace DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> ExtFile = new Dictionary<string, List<FileInfo>>();
            string[] allfiles = Directory.GetFiles(inputFolderPath);
            StringBuilder output = new StringBuilder();
            foreach (var file in allfiles)
            {
                FileInfo fileinfo = new FileInfo(file); 
                var extension = fileinfo.Extension;
                if (!ExtFile.ContainsKey(extension))
                {
                    ExtFile.Add(extension, new List<FileInfo>());
                }
                ExtFile[extension].Add(fileinfo);
            }
            var sorted =  ExtFile.OrderByDescending(entry => entry.Value.Count).ThenBy(entry => entry.Key);
            foreach (var file in sorted)
            {
                output.AppendLine(file.Key);
                List<FileInfo> filesInfo = file.Value;
                filesInfo.OrderByDescending(file => file.Length);
                foreach (var fileinfo in filesInfo)
                {
                    output.AppendLine($"--{fileinfo.Name} - {fileinfo.Length / 1024:f3}kb");
                }
            }
            return output.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string pathReport = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(pathReport, textContent);
        }
    }
}

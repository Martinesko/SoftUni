namespace CopyBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            FileStream fr = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
            FileStream fw = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
            byte[] sourceBytes;
            using (fw)
            {
                sourceBytes = File.ReadAllBytes(inputFilePath);
                for (int i = 0; i < sourceBytes.Length; i++)
                {
                    fw.WriteByte(sourceBytes[i]);
                }
            }
        }
    }
}

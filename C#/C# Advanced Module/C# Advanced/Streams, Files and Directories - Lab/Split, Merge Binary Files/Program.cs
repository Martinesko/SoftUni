using System;

namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] sourcebytes = File.ReadAllBytes(sourceFilePath);
            var secondFileStream = new FileStream(partTwoFilePath, FileMode.Open);
            var firstFileStream = new FileStream(partOneFilePath, FileMode.Open);
            using (firstFileStream)
            {
                using (secondFileStream)
                {
                    for (int i = 0; i < sourcebytes.Length; i++)
                    {
                        if (i % 2 == 0)
                        {


                            firstFileStream.WriteByte(sourcebytes[i]);

                        }
                        else
                        {


                            secondFileStream.WriteByte(sourcebytes[i]);

                        }
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            var createdFile = new FileStream(joinedFilePath, FileMode.OpenOrCreate);
            var firstFileStream = new FileStream(partOneFilePath, FileMode.Open);
            var secondFileStream = new FileStream(partTwoFilePath, FileMode.Open);
            var curbyte = new byte[1024];
            using (createdFile)
            {
                using (firstFileStream)
                {
                    using (secondFileStream)
                    {
                        for (int i = 0; i < firstFileStream.Length + secondFileStream.Length; i++)
                        {
                            if (i % 2 == 0)
                            {

                                createdFile.WriteByte((byte)firstFileStream.ReadByte());

                            }
                            else
                            {
                                createdFile.WriteByte((byte)secondFileStream.ReadByte());
                            }
                        }
                    }
                }
            }
        }
    }
}
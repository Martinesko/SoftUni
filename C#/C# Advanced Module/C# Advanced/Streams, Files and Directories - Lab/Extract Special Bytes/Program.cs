using System;

namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            //var binaryFileStream = new FileStream(binaryFilePath,FileMode.Open);
            var outputStream = new FileStream(outputPath, FileMode.OpenOrCreate);
            var reader = new StreamReader(bytesFilePath);
           List<byte> output = new List<byte>();
            List<int> bytes = new List<int>();
            byte[] allbytes;
            
                allbytes = File.Read(binaryFilePath);
            
            using (reader)
            {
                while (true)
                {
                    string n = reader.ReadLine();
                    if (n == null)
                    {
                        break;
                    }
                    bytes.Add(int.Parse(n));
                   
                }
               
            }
            for (int i = 0; i < allbytes.Length; i++)
            {
               byte curbyte = allbytes[i];
                for (int j = 0; j < bytes.Count; j++)
                {
                    if (allbytes[i] == bytes[j])
                    {
                        break;
                    }
                    else if(j+1 == bytes.Count)
                    {
                        output.Add(allbytes[i]); 
                    }

                }
            }
            byte[] finaloutput = new byte[255];
            for (int i = 0; i < 255; i++)
            {
                finaloutput[i] = output[i];
            }
            using (outputStream)
            {
                outputStream.Write(finaloutput);
            }
        }
    }
}


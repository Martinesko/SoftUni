using System;
using System.Linq;

namespace Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
         string[] firstArry = Console.ReadLine().Split().ToArray();
         string[] secondArry= Console.ReadLine().Split().ToArray();
            string compWord = string.Empty;

            for (int i = 0; i < secondArry.Length; i++)
            {
                compWord = secondArry[i];
                for (int j = 0; j < firstArry.Length;j++)
                {
                    if (compWord == firstArry[j])
                    {
                        Console.Write($"{compWord} ");
                    }
                }
            }
        }
    }
}

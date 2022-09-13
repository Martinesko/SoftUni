using System;
using System.Linq;

namespace Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] stringArry = Console.ReadLine().Split().ToArray();
            string combo = "";
            for (int i = stringArry.Length -1; i >= 0; i--)
            {
                if (i == stringArry.Length-1)
                {
                    combo = stringArry[i];
                }
                else
                {
                 combo = $"{combo} {stringArry[i]}";
                }
                
            }
            Console.WriteLine(combo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                List<string> funcsion = Console.ReadLine().Split().ToList();
                switch (funcsion[0])
                {
                    case "swap":
                        int first = numberList[int.Parse(funcsion[1])];
                        int second = numberList[int.Parse(funcsion[2])];
                        numberList[int.Parse(funcsion[1])] = second;
                        numberList[int.Parse(funcsion[2])] = first;
                        break;
                    case "multiply":
                        int firstmulti = numberList[int.Parse(funcsion[1])];
                        int secondmulti = numberList[int.Parse(funcsion[2])];
                        numberList[int.Parse(funcsion[1])] = firstmulti * secondmulti;
                        break;
                    case "decrease":
                        for (int i = 0; i < numberList.Count; i++)
                        {
                            numberList[i]--;
                        }
                        break;
                    default:
                        break;

                }
                if (funcsion[0] == "end")
                {
                    Console.WriteLine(string.Join(", ", numberList));
                    break;
                }
            }
            
        }
    }
}

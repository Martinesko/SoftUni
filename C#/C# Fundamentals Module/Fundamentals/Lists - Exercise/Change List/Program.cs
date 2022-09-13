using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numberList = Console.ReadLine().Split().Select(double.Parse).ToList();
            while (true)
            {
                List<string> funcion = Console.ReadLine().Split().ToList();
                switch (funcion[0])
                {
                    case "Delete":
                        int counter = 0;
                        for (int i = 0; i < numberList.Count; i++)
                        {                           
                            if (numberList[i]<= double.Parse(funcion[1]))
                            {
                                counter++;  
                            }
                        }
                        for (int j = 0; j < counter; j++)
                        {
                            numberList.Remove(double.Parse(funcion[1]));
                        }
                        break;
                    case "Insert":
                        numberList.Insert(int.Parse(funcion[2]), double.Parse(funcion[1]));
                        break;
                    default:
                        break;
                }
                if (funcion[0] == "end")
                {
                    break;
                }
            }
            Console.WriteLine(String.Join(" ",numberList));
        }
    }
}

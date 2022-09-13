using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
         List<double> numberList = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<string> funcion = new List <string>();
            while (true)
            {
                funcion = Console.ReadLine().Split().ToList();
                switch (funcion[0])
                {
                    case "Add":                        
                        int addedNumber = int.Parse(funcion[1]);
                        numberList.Add(addedNumber);
                        break;
                    case "Remove":
                        int removedNumber = int.Parse(funcion[1]);
                        numberList.Remove(removedNumber);
                        break;
                    case "RemoveAt":
                        int removedIndex = int.Parse(funcion[1]);
                        numberList.RemoveAt(removedIndex);
                        break;
                    case "Insert":
                        int insertedNumber = int.Parse(funcion[1]);
                        int insertedIndex = int.Parse(funcion[2]);
                        numberList.Insert(insertedIndex, insertedNumber);
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

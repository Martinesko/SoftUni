using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numberList = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<string> funcion = new List<string>();
            bool flag = false;
            while (true)
            {
                funcion = Console.ReadLine().Split().ToList();
                switch (funcion[0])
                {
                    case "Contains":
                        if (numberList.Contains(double.Parse(funcion[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        List<double> printEven = new List<double>();
                        for (int i = 0; i < numberList.Count; i++)
                        {
                            if (numberList[i] % 2 == 0)
                            {
                                printEven.Add(numberList[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", printEven));
                        break;
                    case "PrintOdd":
                        List<double> printOdd = new List<double>();
                        for (int i = 0; i < numberList.Count; i++)
                        {
                            if (numberList[i] % 2 != 0)
                            {
                                printOdd.Add(numberList[i]);
                            }
                        }
                        Console.WriteLine(String.Join(" ", printOdd));
                        break;
                    case "GetSum":
                        double sum = 0;
                        for (int i = 0; i < numberList.Count; i++)
                        {
                            sum += numberList[i];
                        }
                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        switch (funcion[1])
                        {
                            case "<":
                                List<double> lowerList = new List<double>();
                                for (int i = 0; i < numberList.Count; i++)
                                {
                                    if (numberList[i] < double.Parse(funcion[2]))
                                    {
                                        lowerList.Add(numberList[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", lowerList));
                                break;
                            case ">":
                                List<double> higherList = new List<double>();
                                for (int i = 0; i < numberList.Count; i++)
                                {
                                    if (numberList[i] > double.Parse(funcion[2]))
                                    {
                                        higherList.Add(numberList[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", higherList));
                                break;
                            case ">=":
                                List<double> higherorList = new List<double>();
                                for (int i = 0; i < numberList.Count; i++)
                                {
                                    if (numberList[i] >= double.Parse(funcion[2]))
                                    {
                                        higherorList.Add(numberList[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", higherorList));
                                break;
                            case "<=":
                                List<double> lowerorList = new List<double>();
                                for (int i = 0; i < numberList.Count; i++)
                                {
                                    if (numberList[i] <= double.Parse(funcion[2]))
                                    {
                                        lowerorList.Add(numberList[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", lowerorList));
                                break;
                            case "Add":
                                int addedNumber = int.Parse(funcion[1]);
                                numberList.Add(addedNumber);
                                flag = true;
                                
                                break;
                            case "Remove":
                                int removedNumber = int.Parse(funcion[1]);
                                numberList.Remove(removedNumber);
                                
                                flag = true;
                                break;
                            case "RemoveAt":
                                int removedIndex = int.Parse(funcion[1]);
                                numberList.RemoveAt(removedIndex);
                                
                                flag = true;
                                break;
                            case "Insert":
                                int insertedNumber = int.Parse(funcion[1]);
                                int insertedIndex = int.Parse(funcion[2]);
                                numberList.Insert(insertedIndex, insertedNumber);
                                
                                flag = true;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                if (funcion[0] == "end")
                {
                    if (flag == true)
                    {
                        Console.WriteLine(string.Join(" ", numberList));
                    }
                    break;
                }
            }


        }
    }
}

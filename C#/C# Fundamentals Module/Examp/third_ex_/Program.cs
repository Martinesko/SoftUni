using System;
using System.Linq;
using System.Collections.Generic;

namespace third_ex_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shelfList = Console.ReadLine().Split("&").ToList();
            List<string> command = new List<string>();

            while (true)
            {
                command = Console.ReadLine().Split(" | ").ToList();
                bool isThere = false;
                switch (command[0])
                {
                    case "Add Book":
                        for (int i = 0; i < shelfList.Count; i++)
                        {
                            if (command[1] == shelfList[i])
                            {
                                isThere = true;
                                break;
                            }
                        } 
                            if (isThere == false)
                            {
                                shelfList.Insert(0, command[1]);
                            }
                        
                        break;
                    case "Take Book":
                        for (int i = 0; i < shelfList.Count; i++)
                        {
                            if (command[1] == shelfList[i])
                            {
                                shelfList.Remove(command[1]);                              
                            }
                            if (i == shelfList.Count-1)
                            {
                                 break;
                            }
                            
                        }
                        break;
                    case "Swap Books":
                        bool isThereFirst = false;
                        bool isThereSecond = false;
                        string firstBook = command[1];
                        string secondBook = command[2];
                        int firstIndex = 0;
                        int secondIndex = 0;
                        for (int i = 0; i < shelfList.Count; i++)
                        {                   
                            if (command[1] == shelfList[i])
                            {
                                firstIndex = i;
                                isThereFirst = true;
                            }
                        }
                        for (int i = 0; i < shelfList.Count; i++)
                        {
                            if (command[2] == shelfList[i])
                            {
                                secondIndex = i;
                                isThereSecond = true;
                            }
                        }
                        if (isThereFirst == true && isThereSecond == true)
                        {
                            shelfList[firstIndex] = secondBook;
                            shelfList[secondIndex] = firstBook;
                        }
                        break;
                    case "Insert Book":
                        for (int i = 0; i < shelfList.Count; i++)
                        {
                            if (command[1] == shelfList[i])
                            {
                                isThere = true;
                                break;
                            }
                        }
                        if (!isThere)
                        {
                            shelfList.Add(command[1]);
                        }
                        break;
                    case "Check Book":
                        if (int.Parse(command[1]) >= 0 && int.Parse(command[1])< shelfList.Count)
                        {
                            Console.WriteLine(shelfList[int.Parse(command[1])]);
                        }
                        break;
                    default:
                        break;
                }
                if (command[0] == "Done")
                {
                   Console.WriteLine(string.Join(", ",shelfList));
                    break;
                }
            }
        }
    }
}

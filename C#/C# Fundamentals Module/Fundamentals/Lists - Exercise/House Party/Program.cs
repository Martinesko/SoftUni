using System;
using System.Linq;
using System.Collections.Generic;

namespace House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfComands = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();
            bool flag = false;
            for (int currentComand = 0; currentComand < numberOfComands; currentComand++)
            {
                List<string> command = Console.ReadLine().Split().ToList();
                flag = false;
                if (!guestList.Any())
                {
                    guestList.Add(command[0]);
                    flag = true;
                }
                if (command[2] == "going!" && flag == false)
                {
                    for (int i = 0; i < guestList.Count; i++)
                    {

                        if (guestList[i] == command[0])
                        {
                            Console.WriteLine($"{command[0]} is already in the list!");
                            flag = true;
                            break;
                        }
                        if (i == guestList.Count-1)
                        {
                            guestList.Add(command[0]);
                        }
                    }
                }
                else if (command[2] == "not" && flag == false)
                {
                    for (int i = 0; i < guestList.Count; i++)
                    {
                        bool flag2 = false;
                        if (guestList[i] == command[0])
                        {
                            guestList.Remove(command[0]);
                            flag2 = true;
                        }
                        else if (i == guestList.Count-1)                                            
                        {
                            Console.WriteLine($"{command[0]} is not in the list!");
                        }
                    }
                }

            }
            Console.WriteLine(String.Join(" ", guestList));
        }
    }
}

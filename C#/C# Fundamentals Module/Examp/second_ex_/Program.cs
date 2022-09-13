using System;
using System.Linq;
using System.Collections.Generic;

namespace second_ex_
{
    internal class Program
    {
        static void Main(string[] args)
        {
         List<string> friendList = Console.ReadLine().Split(", ").ToList();
            int errorCounter = 0;
            int blacklistedCounter = 0;
            int index = 0;
            while (true)
            {
                List<string> command = Console.ReadLine().Split(" ").ToList();
                switch (command[0])
                {
                    case "Blacklist":
                        for (int i = 0; i < friendList.Count; i++)
                        {
                            if (command[1] == friendList[i])
                            {
                                friendList[i] = "Blacklisted";
                                Console.WriteLine($"{command[1]} was blacklisted.");
                                blacklistedCounter++;
                                break;
                            }
                             if (i == friendList.Count-1)
                            {
                                Console.WriteLine($"{command[1]} was not found.");
                            }
                        }
                        break;
                    case "Error":
                        index = int.Parse(command[1]);
                        if (index >= 0 && index < friendList.Count && friendList[index] != "Lost" && friendList[index] != "Blacklisted")
                        {
                            Console.WriteLine($"{friendList[index]} was lost due to an error.");
                            friendList[index] = "Lost";
                            errorCounter++;
                        }
                        break;
                    case "Change":
                        index = int.Parse(command[1]);
                        if (index >= 0 && index < friendList.Count)
                        { 
                            
                            Console.WriteLine($"{friendList[index]} changed his username to {command[2]}.");
                                 friendList[index] = command[2];                         
                        }
                        break;
                    default:
                        break;
                }
                if (command[0] == "Report")
                {
                    Console.WriteLine($"Blacklisted names: {blacklistedCounter}");
                    Console.WriteLine($"Lost names: {errorCounter}");
                    Console.WriteLine(string.Join(" ",friendList));
                    break;
                }
            }
        }
    }
}

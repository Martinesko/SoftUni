using System;
using System.Linq;
using System.Collections.Generic;

namespace Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<string>> companyIDs = new Dictionary<string,List<string>>();
            while (true)
            {
                List<string> commands = Console.ReadLine().Split(" -> ").ToList();
                if (commands[0] == "End")
                {
                    break;
                }
                string companyName = commands[0];
                string ID = commands[1];
                
                if (!companyIDs.ContainsKey(companyName))
                {
                    companyIDs.Add(companyName, new List<string>());
                    companyIDs[companyName].Add(ID);
                }
                else
                {
                    if (!companyIDs[companyName].Contains(ID))
                    {
                     companyIDs[companyName].Add(ID);
                    }
                }
            }
            foreach (var item in companyIDs)
            {
                Console.WriteLine(item.Key);
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.WriteLine($"-- {item.Value[i]}");
                }
            }
        }
    }
}

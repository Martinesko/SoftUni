using System;
using System.Linq;
using System.Collections.Generic;

namespace Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> NameAge = new Dictionary<string, int>();
            Dictionary<string, int> NameAgeSorted = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string tempName = command[0];
                int tempAge = int.Parse(command[1]);
                if (!NameAge.ContainsKey(tempName))
                {
                    NameAge.Add(tempName, tempAge);
                }
            }
            string YoungerOrOlder = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string nameOrAge = Console.ReadLine();
            switch (YoungerOrOlder)
            {
                case "younger":
                    foreach (var curNameAge in NameAge)
                    {
                        if (curNameAge.Value < age)
                        {
                            NameAgeSorted.Add(curNameAge.Key, curNameAge.Value);
                        }
                    }
                    break;
                case "older":
                    foreach (var curNameAge in NameAge)
                    {
                        if (curNameAge.Value >= age)
                        {
                            NameAgeSorted.Add(curNameAge.Key, curNameAge.Value);
                        }
                    }
                    break;
                default:
                    break;
            }
            switch (nameOrAge)
            {
                case "name age":
                    foreach (var curNameAge in NameAgeSorted)
                    {
                        Console.WriteLine($"{curNameAge.Key} - {curNameAge.Value}");
                    }
                    break;
                case "name":
                    foreach (var curNameAge in NameAgeSorted)
                    {
                        Console.WriteLine($"{curNameAge.Key}");
                    }
                    break;
                case "age":
                    foreach (var curNameAge in NameAgeSorted)
                    {
                        Console.WriteLine($"{curNameAge.Value}");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

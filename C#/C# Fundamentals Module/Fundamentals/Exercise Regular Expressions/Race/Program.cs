using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> NameDistance = new Dictionary<string, int>();
            List<string> NameList = Console.ReadLine().Split(", ").ToList();
            foreach (var item in NameList)
            {
                NameDistance.Add(item, 0);
            }
            string NameRegex = @"[A-Za-z]";
            string distanceRegex = @"[0-9]";
            while (true)
            {
                string input = Console.ReadLine();
                string stringName = "";
                if (input == "end of race")
                {
                    break;
                }
                var regexedName = Regex.Matches(input, NameRegex);
                var regexedDistance = Regex.Matches(input, distanceRegex);
                foreach (var item2 in regexedName)
                {
                    string stringItem = item2.ToString();
                    stringName = $"{stringName}{stringItem}";
                }
                foreach (var item in NameDistance)
                {
                    if (item.Key == stringName)
                    {
                        foreach (var item1 in regexedDistance)
                        {
                            string stringDistance = item1.ToString();
                            int intDistance = int.Parse(stringDistance);
                            NameDistance[item.Key] += intDistance;
                        }
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {

                string atPlace = "";
                int min = int.MinValue;
                foreach (var item in NameDistance)
                {
                    int current = item.Value;
                    if (current > min)
                    {
                        min = current;
                      atPlace = item.Key;
                    }
                }
                if (i == 0)
                {
                    Console.WriteLine($"1st place: {atPlace}");
                    NameDistance.Remove(atPlace);
                }
                else if (i == 1)
                {
                    Console.WriteLine($"2nd place: {atPlace}");
                    NameDistance.Remove(atPlace);
                }
                else if (i == 2)
                {
                    Console.WriteLine($"3rd place: {atPlace}");
                    NameDistance.Remove(atPlace);
                }
            }
        }
    }
}

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(#|\|)(?<name>[A-Za-z, ]+)\1(?<day>[0-9]{2})\/(?<month>[0-9]{2})\/(?<year>[0-9]{2})\1(?<calories>[0-9]+)\1";
            string input = Console.ReadLine();
            var matches = Regex.Matches(input, regex);
            int totalNutrition = 0;
            int days = 0;
            foreach (Match match in matches)
            {
                totalNutrition += int.Parse(match.Groups["calories"].Value);

            }
            while (totalNutrition - 2000 >= 0)
            {
                days++;
                totalNutrition -= 2000;
            }
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["name"].Value}, Best before: {item.Groups["day"].Value}/{item.Groups ["month"].Value}/{item.Groups["year"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }
        }
    }
}

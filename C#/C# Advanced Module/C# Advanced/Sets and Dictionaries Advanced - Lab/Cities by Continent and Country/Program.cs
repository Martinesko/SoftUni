using System;
using System.Linq;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           Dictionary<string, Dictionary<string, List<string>>> ContinentCountryCities = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!ContinentCountryCities.ContainsKey(continent))
                    ContinentCountryCities.Add(continent, new Dictionary<string, List<string>>());

                if (!ContinentCountryCities[continent].Keys.Contains(country))
                    ContinentCountryCities[continent].Add(country, new List<string>());            

                ContinentCountryCities[continent][country].Add(city);

            }
            foreach (var continent in ContinentCountryCities)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {String.Join(", " , country.Value)}");
                } 
            }
        }
    }
}

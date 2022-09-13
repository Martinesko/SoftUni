using System;
using System.Linq;
using System.Collections.Generic;


namespace Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
           Dictionary<string,int> Materialvalue = new Dictionary<string,int>();
            Materialvalue.Add("shards", 0);
            Materialvalue.Add("fragments", 0);
            Materialvalue.Add("motes", 0);
            bool flag = false;

            while(flag == false)
            {
                List<string> items = Console.ReadLine().Split().ToList();
                for (int i = 1; i < items.Count; i++)
                {
                   
                    string loweredword = items[i].ToLower();

                    if (!Materialvalue.ContainsKey(loweredword))
                    {
                        Materialvalue.Add(loweredword, int.Parse(items[i - 1]));
                    }
                    else
                    {
                        Materialvalue[loweredword] += int.Parse(items[i - 1]);
                    }
                    i++;
                    if (Materialvalue.ContainsKey("shards") && Materialvalue["shards"] >= 250)
                    {
                        Materialvalue["shards"] -= 250;
                        Console.WriteLine("Shadowmourne obtained!");
                        flag = true;
                        break;
                    }
                    else if (Materialvalue.ContainsKey("fragments") && Materialvalue["fragments"] >= 250)
                    {
                        Materialvalue["fragments"] -= 250;
                        Console.WriteLine("Valanyr obtained!");
                        flag = true;
                        break;
                    }
                    else if (Materialvalue.ContainsKey("motes") && Materialvalue["motes"] >= 250)
                    {
                        Materialvalue["motes"] -= 250;
                        Console.WriteLine("Dragonwrath obtained!");
                        flag = true;
                        break;
                    }
                }
            }
            Console.WriteLine($"shards: {Materialvalue["shards"]}");
            Console.WriteLine($"motes: {Materialvalue["motes"]}");
            Console.WriteLine($"fragments: {Materialvalue["fragments"]}");
            
            Materialvalue.Remove("shards");
            Materialvalue.Remove("fragments");
            Materialvalue.Remove("motes");

            foreach (var item in Materialvalue)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

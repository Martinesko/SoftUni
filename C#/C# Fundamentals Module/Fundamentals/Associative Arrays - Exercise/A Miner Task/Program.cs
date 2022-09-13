using System;
using System.Linq;
using System.Collections.Generic;

namespace A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Dictionary<string , int> OrePrice = new Dictionary<string , int>();
          string command = string.Empty;
          int price = 0;
            
            while (true)
            {
                command = Console.ReadLine();
                if (command == "stop")
                {
                    break;
                }
                price = int.Parse(Console.ReadLine());
                if (!OrePrice.ContainsKey(command))
                {
                    OrePrice.Add(command, price);
                }
                else
                {
                    OrePrice[command] += price;
                }
            }
            foreach (var item in OrePrice)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}

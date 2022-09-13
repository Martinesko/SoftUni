using System;
using System.Collections.Generic;
using System.Linq;

namespace Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targetsList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int index = 0;
            int power = 0;
            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                if (commands[0] == "End")
                {
                    Console.WriteLine($"{string.Join("|" , targetsList)}");
                    break;
                }
                index = int.Parse(commands[1]);
                power = int.Parse(commands[2]);
                switch (commands[0])
                {
                    case "Shoot":
                        targetsList[index] = targetsList[index] - power;
                        if (targetsList[index] <= 0)
                        {
                            targetsList.RemoveAt(index);
                        }
                        break;
                    case "Add":
                        if (index < 0 || index > targetsList.Count)
                        {
                            Console.WriteLine("Invalid placement!");
                            break;
                        }
                        else
                        {
                            targetsList[index] += power;

                        }
                        
                        break;
                    case "Strike":
                        if (index - power < 0 || index + power > targetsList.Count)
                        {
                            Console.WriteLine("Strike missed!");
                            break;
                        }
                        else
                        {
                         for (int i = index - power; i < index + power; i++)
                        {
                            targetsList.RemoveAt(index-power);
                        }
                        }
                        
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}

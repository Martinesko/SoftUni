using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int reps = int.Parse(Console.ReadLine());
            Dictionary<string,string> memberAndPlate = new Dictionary<string,string>();
          
            for (int i = 0; i < reps; i++)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                switch (commands[0])
                {
                    case "register":
                        if (!memberAndPlate.ContainsKey(commands[1]))
                        {
                            memberAndPlate.Add(commands[1], commands[2]);
                            Console.WriteLine($"{commands[1]} registered {commands[2]} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {commands[2]}");
                        }
                        break;
                    case "unregister":
                        if (memberAndPlate.ContainsKey(commands[1]))
                        {
                            Console.WriteLine($"{commands[1]} unregistered successfully");
                            memberAndPlate.Remove(commands[1]);
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {commands[1]} not found");
                        }
                        break;
                    default:
                        break;
                }
            }
            foreach (var member in memberAndPlate)
            {
                Console.WriteLine($"{member.Key} => {member.Value}");
            }
        }
    }
}

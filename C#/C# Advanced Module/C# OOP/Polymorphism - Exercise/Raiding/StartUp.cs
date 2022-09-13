using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            List<BaseHero> list = new List<BaseHero>();
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string Name = Console.ReadLine();
                string Type = Console.ReadLine();
                switch (Type.ToLower())
                {
                    case "paladin":
                        list.Add(new Paladin(Name));
                        break;
                    case "druid":
                        list.Add(new Druid(Name));
                            break;
                    case "warrior":
                        list.Add(new Warrior(Name));
                        break;
                    case "rogue":
                        list.Add(new Rogue(Name));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        i--;
                        break;
                }
            }
            int needed = int.Parse(Console.ReadLine());
            int totalPower = 0;
            foreach (var hero in list)
            {
                totalPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
                if (needed <= totalPower)
                {
                    Console.WriteLine("Victory!");
                    return;
                }
               
            }
            Console.WriteLine("Defeat...");
        }
    }
}

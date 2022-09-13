using System;
using System.Linq;
using System.Collections.Generic;

namespace The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int reps = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> pieceComposerKey  = new Dictionary<string, List<string>>();
            bool flag = true;
            for (int i = 0; i < reps; i++)
            {
                List<string> commands = Console.ReadLine().Split("|").ToList();
                List<string> ComposerKey = new List<string>();
                ComposerKey.Add(commands[1]);
                ComposerKey.Add(commands[2]);
                pieceComposerKey.Add(commands[0],ComposerKey);
            }
            while (flag == true)
            {
                List<string> commands = Console.ReadLine().Split("|").ToList();
                switch (commands[0])
                {
                    case "Add":
                        if (!pieceComposerKey.ContainsKey(commands[1]))
                        {
                            List<string> ComposerKey = new List<string>();
                        ComposerKey.Add(commands[2]);
                        ComposerKey.Add(commands[3]);
                        pieceComposerKey.Add(commands[1], ComposerKey);
                            Console.WriteLine($"{commands[1]} by {commands[2]} in {commands[3]} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{commands[1]} is already in the collection!");
                        }
                        break;
                    case "Remove":
                        if (pieceComposerKey.ContainsKey(commands[1]))
                        {
                            pieceComposerKey.Remove(commands[1]);
                            Console.WriteLine($"Successfully removed {commands[1]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {commands[1]} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        if (pieceComposerKey.ContainsKey(commands[1]))
                        {
                            pieceComposerKey[commands[1]].RemoveAt(1);
                            pieceComposerKey[commands[1]].Insert(2, commands[2]);
                            Console.WriteLine($"Changed the key of {commands[1]} to {commands[2]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {commands[1]} does not exist in the collection.");
                        }
                        break;
                    case "end":
                        flag = false;
                        break;
                    default:
                        break;
                }
                foreach (var item in pieceComposerKey)
                {
                    Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
                }
            }
        }
    }
}

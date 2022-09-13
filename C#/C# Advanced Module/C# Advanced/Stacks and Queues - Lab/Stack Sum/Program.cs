using System;
using System.Linq;
using System.Collections.Generic;

namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputStack = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> Stack = new Stack<int>();
            foreach (var item in inputStack)
            {
                Stack.Push(item);
            }
            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                if (commands[0].ToLower() == "end")
                {
                    break;
                }
                switch (commands[0].ToLower())
                {
                    case "add":
                        Stack.Push(int.Parse(commands[1]));
                        Stack.Push(int.Parse(commands[2]));
                        break;
                    case "remove":
                        if (int.Parse(commands[1])>Stack.Count)
                        {
                            break;
                        }
                        for (int i = 0; i < int.Parse(commands[1]); i++)
                        {
                       
                            Stack.Pop();
                        }
                        
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Sum: {Stack.Sum()}");


        }
    }
}

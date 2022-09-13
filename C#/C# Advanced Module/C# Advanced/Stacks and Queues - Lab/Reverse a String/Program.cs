using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
         string input = Console.ReadLine();
        Stack<char> Stack = new Stack<char>();
            foreach (char item in input)
            {
                Stack.Push(item);
            }
            while (Stack.Count > 0)
            {
                Console.Write(Stack.Pop());
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputStack = Console.ReadLine().Split().ToArray();
            Stack<string> Stack = new Stack<string>();
            int firstnumber = 0;
            int sum = 0;
            for (int i = inputStack.Length; i > 0; i--)
            {
                Stack.Push(inputStack[i-1]);
            }
            sum = int.Parse(Stack.Pop());
            while (Stack.Count != 0)
            {
                switch (Stack.Pop())
                {
                    case "-":
                        sum -= firstnumber + int.Parse(Stack.Pop());
                        break;
                        case "+":
                        sum += firstnumber + int.Parse(Stack.Pop());
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine(sum);

        }
    }
}

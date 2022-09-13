using System;
using System.Linq;

namespace Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            while (true)
            {
                string command = Console.ReadLine(); 
                switch(command)
                {
                    case "add":
                        numbers = numbers.Select(n=> n+1).ToArray();
                    break;
                    case "multiply":
                        numbers = numbers.Select(n=> n = n*2).ToArray();
                    break;
                     case "subtract":
                        numbers = numbers.Select(n=> n = n-1).ToArray();
                    break;
                     case "print":
                        Console.WriteLine(String.Join(" ",numbers));
                    break;
                    case  "end":
                        return;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}

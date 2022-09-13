using System;
using System.Collections.Generic;
using System.Linq;

namespace Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targetArry = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int accuretshots = 0;
            int targetValue = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                if (int.Parse(command) >= targetArry.Length)
                {
                    continue;
                }
                accuretshots++;
                targetValue = targetArry[int.Parse(command)];
                targetArry[int.Parse(command)] = -1;
                for (int i = 0; i < targetArry.Length; i++)
                {
                    if (targetArry[i] != -1)
                    {
                       
                     if (i == int.Parse(command))
                    {
                        continue;
                    }
                    if (targetArry[i] > targetValue)
                    {
                        targetArry[i] -= targetValue;
                    }
                    else
                    {
                        targetArry[i] += targetValue;
                    }
                    }
                   
                }
            }
            Console.WriteLine($"Shot targets: {accuretshots} -> {String.Join(" ",targetArry)}");
        }
    }
}

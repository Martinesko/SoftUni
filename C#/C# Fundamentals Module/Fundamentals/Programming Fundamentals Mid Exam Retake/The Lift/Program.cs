using System;
using System.Linq;
using System.Collections.Generic;

namespace The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
         int people = int.Parse(Console.ReadLine());
         List<int> liftList = Console.ReadLine().Split().Select(int.Parse).ToList();
                for (int i = 0; i < liftList.Count; i++)
                {
                if (liftList[i] < 4)
                {
                      liftList[i]+= 1;
                    people--;
                    if (liftList[i]!=4)
                    {
                        i--;
                    }
                
                }
                  if (people<=0)
                {
                    break;
                }
                }
            if (liftList[liftList.Count - 1] == 4 && people == 0) 
            {
                Console.WriteLine(String.Join(" ", liftList));
            }
            else if (people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(String.Join(" ", liftList));
            }
            else if (people <= 0 && liftList[liftList.Count-1] != 4)
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(String.Join(" ", liftList));
            }
        }
    }
}

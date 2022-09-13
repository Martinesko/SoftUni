using System;
using System.Linq;
using System.Collections.Generic;

namespace Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<int> givenPetrol = new Queue<int>();
            Queue<int> neededPetrol = new Queue<int>();
            int index = -1;
            int currentPetrol = 0;
            bool correctStart = false;
            for (int i = 0; i < petrolPumps; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                givenPetrol.Enqueue(input[0]);
                neededPetrol.Enqueue(input[1]);
            }
            while (correctStart != true)
            {
                index++;
                currentPetrol = 0;
                for (int currentPump = 0; currentPump < petrolPumps; currentPump++)
                {
                    int currentPetrolPump = givenPetrol.Dequeue();
                    int nextPetrolPumpDistance = neededPetrol.Dequeue();
                    currentPetrol += currentPetrolPump;
                    if (currentPetrol < nextPetrolPumpDistance)
                    {
                        givenPetrol.Enqueue(currentPetrolPump);
                        neededPetrol.Enqueue(nextPetrolPumpDistance);
                        break;
                    }
                    if (currentPump == petrolPumps - 1)
                    {
                        correctStart = true;
                    }
                }
            }
            Console.WriteLine(index);
        }
    }
}

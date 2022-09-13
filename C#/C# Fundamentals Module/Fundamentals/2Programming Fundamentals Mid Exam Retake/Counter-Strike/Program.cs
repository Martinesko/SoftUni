using System;

namespace Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int givenEnergy = int.Parse(Console.ReadLine());
            int battleCount = 0;
            bool flag = false;
            while (flag == false)
            {
                string distance = Console.ReadLine();
                if (distance == "End of battle")
                {
                    Console.WriteLine($"Won battles: {battleCount}. Energy left: {givenEnergy}");
                    break;
                }
                else if (battleCount % 3 == 0 && battleCount != 0)
                {
                    givenEnergy += battleCount;
                }
                if (int.Parse(distance) <= givenEnergy)
                {
                    battleCount++;
                    givenEnergy -= int.Parse(distance);
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battleCount} won battles and {givenEnergy} energy");
                    flag = true;
                }
            }
            Console.WriteLine();
        }
    }
}

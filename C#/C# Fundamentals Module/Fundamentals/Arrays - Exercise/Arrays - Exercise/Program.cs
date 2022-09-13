using System;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] peoplePerWagon = new int[wagons];
            int sum = 0;
            for (int i = 0; i < peoplePerWagon.Length; i++)
            {
                peoplePerWagon[i] = int.Parse(Console.ReadLine());
                sum += peoplePerWagon[i];
            }
            for (int j = 0; j < peoplePerWagon.Length; j++)
            {
                Console.Write($"{peoplePerWagon[j]} ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
            
        }
    }
}

using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[size][];
            bool isEND = false;
            for (int i = 0; i < size; i++)
            {
                jaggedArray[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                switch (command[0])
                {
                    case "Add":
                        if (int.Parse(command[1]) < 0 || int.Parse(command[2])>=jaggedArray.Length)
                        {
                            Console.WriteLine("Invalid coordinates");
                            break;
                        }
                        jaggedArray[int.Parse(command[1])][int.Parse(command[2])] = jaggedArray[int.Parse(command[1])][int.Parse(command[2])] + int.Parse(command[3]);
                        break;
                    case "Subtract":
                        if (int.Parse(command[1]) < 0 || int.Parse(command[2]) >= jaggedArray.Length)
                        {
                            Console.WriteLine("Invalid coordinates");
                            break;
                        }
                        jaggedArray[int.Parse(command[1])][int.Parse(command[2])] = jaggedArray[int.Parse(command[1])][int.Parse(command[2])] - int.Parse(command[3]);
                        break;
                    case "END":
                        isEND = true;
                        break;
                    default:
                        break;
                }
                if (isEND == true)
                {
                    break;
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}

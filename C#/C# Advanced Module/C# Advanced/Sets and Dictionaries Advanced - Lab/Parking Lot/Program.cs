using System;
using System.Linq;
using System.Collections.Generic;

namespace Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
         HashSet<string> parking = new HashSet<string>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();
                string command = input[0];
                if (command == "END")
                    break;
                string plateNumber = input[1];
                
                if (command == "IN")
                    parking.Add(plateNumber);
                if (command == "OUT")
                    parking.Remove(plateNumber);
                
            }
            if (parking.Count==0)
                Console.WriteLine("Parking Lot is Empty");
            else
                foreach (var car in parking)
                    Console.WriteLine(car);                         
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;


namespace SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            HashSet<string> Regular = new HashSet<string>();
            HashSet<string> VIP = new HashSet<string>();
            while (true)
            {
                string guestNumber = Console.ReadLine();
                if (guestNumber == "PARTY")
                    break;
                char[] number = guestNumber.ToCharArray();
                if ((int)number[0] >= 48 || (int)number[0] <= 57)
                    VIP.Add(guestNumber);
                else
                Regular.Add(guestNumber);
            }
            while (true)
            {
                string guestNumber = Console.ReadLine();
                if (guestNumber == "END")
                    break;
                char[] number = guestNumber.ToCharArray();
                if ((int)number[0] >= 48 || (int)number[0] <= 57)
                    VIP.Remove(guestNumber);
                else
                    Regular.Remove(guestNumber);
            }
            int didntcome = Regular.Count + VIP.Count;
            Console.WriteLine(didntcome);
            foreach (var person in VIP)
            {
                Console.WriteLine(person);
            }
            foreach (var person in Regular)
            {
                Console.WriteLine(person);
            }           
        }
    }
}

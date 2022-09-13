using System;
using System.Linq;
using System.Collections.Generic;

namespace Border_Control
{
    public class Program
    {
        static void Main()
        {
            List<IBirthdate> birtdates = new List<IBirthdate>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");
                if (command[0] == "End")
                {
                    break;
                }
                else if(command[0] == "Citizen")
                {
                    ICitizen citizen = new Citizen(command[1], int.Parse(command[2]), command[3], command[4]);
                    birtdates.Add(citizen);
                }
                else if(command[0] == "Pet")
                {
                    IPet pet = new Pet(command[1], command[2]);
                    birtdates.Add(pet);
                }
                else if (command[0] == "robot")
                {
                    IRobot robot = new Robot(command[1],command[2]);
                }
            }
            string givendate = Console.ReadLine();
            foreach (var birtdate in birtdates)
            {
                if (birtdate.Birthdate.Split("/")[2] == givendate)
                {
                    Console.WriteLine(birtdate.Birthdate);
                }
            }
        }
    }
}
